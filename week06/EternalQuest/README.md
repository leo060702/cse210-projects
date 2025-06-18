
# Eternal Quest Program

This C# console application was created as part of the CSE 210 course to demonstrate object-oriented programming principles, especially **polymorphism**.

## 📌 Project Summary

The Eternal Quest program allows users to create and manage different types of personal goals. It uses **inheritance** and **polymorphism** to handle the different goal behaviors in a clean and scalable way.

### Supported Goal Types

- **Simple Goal**: A one-time goal that gives points upon completion.
- **Eternal Goal**: A repeatable goal that can be recorded infinitely (e.g., daily scripture study).
- **Checklist Goal**: A goal that must be completed a specific number of times to receive a bonus.

### Features

- Create multiple goal types
- Track progress and display completion status
- Record events and update points
- Save and load goal progress from a file
- Display total score earned

## 🧠 Object-Oriented Concepts Applied

- **Abstraction**: Each goal hides internal logic and provides simple interfaces.
- **Encapsulation**: Data and behavior are bundled within each goal class.
- **Inheritance**: All goal types inherit from a common `Goal` base class.
- **Polymorphism**: The program uses a `List<Goal>` to store different goal types and calls common methods like `RecordEvent()` and `GetStatus()` polymorphically.

## ✨ Creative Additions

- Checklist goals show progress like `Completed 2/5 times`
- Eternal goals track how many times they were completed
- Designed a modular structure using `GoalManager.cs` to manage all goals and score in one place

## ▶️ How to Run

1. Compile the program with your preferred C# environment (e.g., Visual Studio or `dotnet` CLI)
2. Run the executable or use `dotnet run` if using a project folder
3. Use the numbered menu to create, record, save, and load goals

## 📂 File Structure

- `Program.cs` – Entry point with user interaction logic
- `Goal.cs` – Abstract base class for all goal types
- `SimpleGoal.cs` – Implements single-completion goals
- `EternalGoal.cs` – Implements never-ending goals
- `ChecklistGoal.cs` – Implements repeatable goals with a bonus
- `GoalManager.cs` – Manages all goals and score logic

---

Created for the **CSE 210** course – Brigham Young University–Idaho.
