using APBD_TASK2.AbstractModels;
using APBD_TASK2.Enums;

namespace APBD_TASK2.Models;

public class Rental
{
    private static int _nextId = 1;
    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; set; } // set; here only for demonstration
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public RentalStatus Status
    {
        get
        {
            if (ReturnDate != null)
                return RentalStatus.Returned;

            if (DateTime.Today > DueDate)
                return RentalStatus.Overdue;

            return RentalStatus.Active;
        }
    }
    
    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        Id = _nextId++;
        User = user;
        Equipment = equipment;
        equipment.Status = EquipmentStatus.Rented;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }
    
    public void CompleteReturn(DateTime returnDate, decimal penalty)
    {
        Equipment.Status = EquipmentStatus.Available;
        ReturnDate = returnDate;
        Penalty = penalty;
    }
    
    public override string ToString()
    {
        return $"{Id}: {Equipment} rented by {User} ";
    }
}