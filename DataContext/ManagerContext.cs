using SMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SMS.DataContext
{
    public class ManagerContext
    {

        private int nextManagerId = 1;

        public List<Manager> Managers { get; set; }
        private readonly string filePath;

        public ManagerContext(string filePath)
        {
            this.filePath = filePath;
            Managers = ReadDataFromCsvAndUpdateId(filePath);
        }

        public void InsertManager(Manager manager)
        {
            manager.Id = nextManagerId++; // Assign the next available Id and increment the counter
            Managers.Add(manager);
            WriteDataToCsv(filePath);
        }

        public void UpdateManager(int managerId, Manager updatedManager)
        {
            Manager existingManager = Managers.FirstOrDefault(p => p.Id == managerId);

            if (existingManager != null)
            {
                existingManager.Name = updatedManager.Name;
                existingManager.Email = updatedManager.Email;
                existingManager.Address = updatedManager.Address;
                existingManager.Username = updatedManager.Username;
                existingManager.Password = updatedManager.Password;
                WriteDataToCsv(filePath);
            }
            else
            {
                Console.WriteLine($"Manager with Id {managerId} not found.");
            }
        }

        public void DeleteManager(int managerId)
        {
            Manager managerToRemove = Managers.FirstOrDefault(p => p.Id == managerId);

            if (managerToRemove != null)
            {
                Managers.Remove(managerToRemove);
                WriteDataToCsv(filePath);
            }
            else
            {
                Console.WriteLine($"Manager with Id {managerId} not found.");
            }
        }

        // Method to read data from a CSV file and populate Pizzas, updating nextPizzaId
        public List<Manager> ReadDataFromCsvAndUpdateId(string filePath)
        {
            Managers = new List<Manager>();
            nextManagerId = 1; // Reset the counter

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header line
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        if (values.Length >= 5)
                        {
                            Manager manager = new Manager
                            {
                                Id = int.Parse(values[0]),
                                Name = values[1],
                                Email = values[2],
                                Username = values[3],
                                Password = values[4]
                            };

                            Managers.Add(manager);

                            // Update nextPizzaId if needed
                            if (manager.Id >= nextManagerId)
                            {
                                nextManagerId = manager.Id + 1;
                            }

                        }
                    }
                }
            }

            return Managers;
        }

        private void WriteDataToCsv(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header
                writer.WriteLine("Id,Name,Email,Address,Username,Password");

                // Write data rows
                foreach (var manager in Managers)
                {
                    writer.WriteLine($"{manager.Id},{manager.Name},{manager.Email},{manager.Username},{manager.Password}");
                }
            }
        }

    }
}
