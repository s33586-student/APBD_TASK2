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
    
}