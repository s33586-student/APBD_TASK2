# APBD_TASK2

## Project description

This project is a console application written in C# for managing a university equipment rental service.  
The system allows adding users, registering equipment, renting and returning devices, marking equipment as unavailable, checking overdue rentals, and generating a short summary report.

The application supports different kinds of equipment, such as laptops, projectors, and cameras. It also supports different user types, including students and employees, with different rental limits depending on the user category.

## Main features

- add a new user
- add a new equipment item
- display all equipment
- display only available equipment
- rent equipment to a user
- return equipment and calculate a late penalty
- mark equipment as unavailable
- display active rentals for a selected user
- display overdue rentals
- generate a summary report of the rental service state

## Project structure

The project is divided into several folders:

- `Enums` – contains enums such as `EquipmentStatus`, `RentalStatus`, and `UserType`
- `AbstractModels` – contains abstract base classes, for example the common `Equipment` type
- `Models` – contains domain classes such as `User`, `Laptop`, `Camera`, `Projector`, and `Rental`
- `Interfaces` – contains interfaces such as `IRentalService`
- `Services` – contains business logic, mainly the `RentalService` class
- `Program.cs` – contains the demonstration scenario and console entry point

## How to run

1. Open the solution in JetBrains Rider.
2. Install .NET SDK of 9.0 version.
3. Build and run the project.
4. The demonstration scenario is executed from `Program.cs`.

## Git workflow

Separate branches were used for implementing parts of the project before merging them into `main`.

Branches:
- `feature-demonstration`
- `feature/rental-service`

#### By S33586