using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_3
{
    internal class Program
    {
        
        class Car
        {
            
            private string brand;
            private string color;
            private int speed;

            
            public void SetCarDetails(string carBrand, string carColor, int carSpeed)
            {
                brand = carBrand;
                color = carColor;
                speed = carSpeed;
            }

            
            public void DisplayCar()
            {
                Console.WriteLine("Car Brand: " + brand);
                Console.WriteLine("Car Color: " + color);
                Console.WriteLine("Car Speed: " + speed + " km/h");
                Console.WriteLine();
            }

            
            public void Drive()
            {
                Console.WriteLine($"{brand} is driving at {speed} km/h.");
            }

            
            public void ApplyBrakes()
            {
                Console.WriteLine($"{brand} has applied brakes and stopped.");
            }
        }

        
        class Demo
        {
            static void Main()
            {
                
                Car car1 = new Car();
                car1.SetCarDetails("Toyota", "Red", 100);   
                car1.DisplayCar();                          
                car1.Drive();                               
                car1.ApplyBrakes();                         

                Console.WriteLine("---------------------------");

                
                Car car2 = new Car();
                car2.SetCarDetails("BMW", "Black", 150);
                car2.DisplayCar();
                car2.Drive();
                car2.ApplyBrakes();
            }
        }

    }
}
