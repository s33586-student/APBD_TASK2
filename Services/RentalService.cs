using APBD_TASK2.AbstractModels;
using APBD_TASK2.Enums;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class RentalService: IRentalService
{
    
    private List<User> users = new();
    private List<Equipment> _equipment = new();
    private List<Rental> rentals = new();
    
    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }

    public Rental RentEquipment(int userId, int equipmentId, int rentalDays)
    {
        var user = users.FirstOrDefault(u => u.Id == userId);
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        
        if (user == null) throw new Exception("User not found");
        if (equipment == null) throw new Exception("Equipment not found");
        if (equipment.Status != EquipmentStatus.Available) 
            throw new Exception("Equipment is unavailable or rented");
        
        int activeRentals = rentals.Count(r => r.User == user && r.Status == RentalStatus.Active);
        if (activeRentals >= user.MaxActiveRentals)
            throw new Exception("User exceeded active rental limit");
        
        Rental rent = new Rental(user, equipment, DateTime.Today, DateTime.Today.AddDays(rentalDays));
        rentals.Add(rent);
        return rent;
    }

    public void ReturnEquipment(int rentalId)
    {
        var rent = rentals.FirstOrDefault(r => r.Id == rentalId);
        if (rent == null) throw new Exception("Rental not found");
        if (rent.Status == RentalStatus.Returned)
            throw new Exception("Equipment has already been returned");
        
        int daysLate = (DateTime.Today - rent.DueDate.Date).Days;
        int penalty = daysLate > 0 ? daysLate * 50 : 0; //50 zl per day
        
        rent.CompleteReturn(DateTime.Today, penalty); 
    }

    public void MarkEquipmentUnavailable(int equipmentId)
    {
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null) throw new Exception("Equipment not found");
        if (equipment.Status == EquipmentStatus.Rented)
            throw new Exception("Cannot mark rented equipment as unavailable");
        
        equipment.Status = EquipmentStatus.Unavailable;
    }

    public List<Rental> GetUserActiveRentals(int userId)
    {
        return rentals.Where(r => r.User.Id == userId && r.Status == RentalStatus.Active).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return rentals.Where(r => r.Status == RentalStatus.Overdue).ToList();
    }

    public string GenerateSummaryReport()
    {
        int userCount = users.Count;
        
        int equipCount = _equipment.Count;
        int availableEquipCount = _equipment.Count(e => e.Status == EquipmentStatus.Available);
        int rentedEquipCount = _equipment.Count(e => e.Status == EquipmentStatus.Rented);
        int unavailableEquipCount = _equipment.Count(e => e.Status == EquipmentStatus.Unavailable);
        
        int rentalsCount = rentals.Count;
        int activeRentalsCount = rentals.Count(r => r.Status == RentalStatus.Active);
        int returnedRentalsCount = rentals.Count(r => r.Status == RentalStatus.Returned);
        int overdueRentalsCount = rentals.Count(r => r.Status == RentalStatus.Overdue);
        
        decimal totalPenalties = rentals.Sum(r => r.Penalty);
        
        return "=========Rental summary============\n"+
               $"Total users: {userCount}\n" +
               $"Total equipment: {equipCount}\n" +
               $"Available equipment: {availableEquipCount}\n" +
               $"Rented equipment: {rentedEquipCount}\n" +
               $"Unavailable equipment: {unavailableEquipCount}\n" +
               $"Total rentals: {rentalsCount}\n" +
               $"Active rentals: {activeRentalsCount}\n" +
               $"Overdue rentals: {overdueRentalsCount}\n" +
               $"Returned rentals: {returnedRentalsCount}\n" +
               $"Total penalties: {totalPenalties} PLN";
    }
    
}