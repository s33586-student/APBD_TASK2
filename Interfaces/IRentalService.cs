using APBD_TASK2.AbstractModels;
using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IRentalService
{
    void AddUser(User user);
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllEquipment();
    List<Equipment> GetAvailableEquipment();
    Rental RentEquipment(int userId, int equipmentId, int rentalDays);
    void ReturnEquipment(int rentalId);
    void MarkEquipmentUnavailable(int equipmentId);
    List<Rental> GetUserActiveRentals(int userId);
    List<Rental> GetOverdueRentals();
    string GenerateSummaryReport();
    
}