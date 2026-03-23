using APBD_TASK2.AbstractModels;
using APBD_TASK2.Enums;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

public class Program
{
    public static void Main(string[] args)
    {
        RentalService rentalService = new RentalService();
        
        Laptop laptop1 = new Laptop("Lappppptop", 12, "gigabyte");
        Projector projector1 = new Projector("Lighhhter", "100x134", 54);
        Camera camera1 = new Camera("Xiaomi Pro 3 Camera", 99999, "Red");
        rentalService.AddEquipment(laptop1);
        rentalService.AddEquipment(projector1);
        rentalService.AddEquipment(camera1);
        
        User student1 = new User("Oleg", "Origam", UserType.Student);
        User emplyee1 = new User("Sans", "Theskeleton", UserType.Employee);
        rentalService.AddUser(student1);
        rentalService.AddUser(emplyee1);
        
        Rental rent = rentalService.RentEquipment(student1.Id, laptop1.Id, 10);
        Console.WriteLine(rent);

        try
        {
            Rental rent2 = rentalService.RentEquipment(emplyee1.Id, laptop1.Id, 9999);
        } catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        rentalService.ReturnEquipment(rent.Id);
        
        Rental rent3 = rentalService.RentEquipment(student1.Id, camera1.Id, 11);
        Rental rent4 = rentalService.RentEquipment(emplyee1.Id, projector1.Id, 234);
        Rental rent5 = rentalService.RentEquipment(emplyee1.Id, laptop1.Id, 64);
        
        rent4.DueDate = DateTime.Today.AddDays(-5); // overdue left
        rent3.DueDate = DateTime.Today.AddDays(-5); 
        
        rentalService.ReturnEquipment(rent3.Id); // return overdue rental
        
        Console.WriteLine(rentalService.GenerateSummaryReport());
        
    }
}