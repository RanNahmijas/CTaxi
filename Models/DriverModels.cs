using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CTaxi.Models
{
    public class DriverModels
    {
        [Required(ErrorMessage = "Licence number is required")]        
        public int LicenceNum { get; set; }

        [Required(ErrorMessage = "Driver name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Driver lastname is required")]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Applying date is required")]
        public DateTime ApplyingDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Last eye check date is required")]
        public DateTime LastEyeCheck { get; set; }
        
        [StringLength(1024)]
        public string Address { get; set; }

        [StringLength(1024)]
        public string EmailAddress { get; set; }       
        public double SeniorityInDays { get; set; }
        public double TimeAfterEyeCheck { get; set; } 
    }

    public class Drivers
    {
        public Drivers()
        {
            _driverList.Add(new DriverModels
            {
                LicenceNum = 1234567,
                Name = "Yossi",
                LastName = "Benayun",
                ApplyingDate = Convert.ToDateTime("11/1/2015"),
                LastEyeCheck = Convert.ToDateTime("2/2/2014"),
                Address = "Haifa",
                EmailAddress = "yossi@example.com",
                SeniorityInDays = 100,
                TimeAfterEyeCheck = 6
            });

            _driverList.Add(new DriverModels
            {
                LicenceNum = 7654321,
                Name = "Moti",
                LastName = "Kakun",
                ApplyingDate = Convert.ToDateTime("10/1/2015"),
                LastEyeCheck = Convert.ToDateTime("20/1/2015"),
                Address = "Petah Tikva",
                EmailAddress = "moti@example.com",
                SeniorityInDays = 200,
                TimeAfterEyeCheck = 5
            });

            _driverList.Add(new DriverModels
            {
                LicenceNum = 1212345,
                Name = "Nahum",
                LastName = "Stelmah",
                ApplyingDate = Convert.ToDateTime("10/2/2015"),
                LastEyeCheck = Convert.ToDateTime("20/5/2015"),
                Address = "Petah Tikva",
                EmailAddress = "Nahum@example.com",
                SeniorityInDays = 10,
                TimeAfterEyeCheck = 2
            });
        }

        public List<DriverModels> _driverList = new List<DriverModels>();

        public void AddDriver(DriverModels driver)
        {
            driver.SeniorityInDays = calcSeniority(driver.ApplyingDate);
            driver.TimeAfterEyeCheck = calcEyeCheck(driver.LastEyeCheck);
            _driverList.Add(driver);
        }

        public void DeleteDriver(DriverModels driver)
        {
            _driverList.Remove(driver);
        }
          
        //calculating SeniorityInDays
        public double calcSeniority(DateTime applyingDate)
        {
            DateTime currDate = DateTime.Now;
            DateTime appDate = applyingDate;            
            TimeSpan seniority = currDate.Subtract(appDate);
            
            return seniority.Days;
        }

        //calculating TimeAfterEyeCheck
        public double calcEyeCheck(DateTime lastEyeCheck)
        {
            DateTime currDate = DateTime.Now;
            double dateInterval = 0;

            if (currDate.Year > lastEyeCheck.Year)
            {
                dateInterval = currDate.Month + 12;
            }
            else
            {
                dateInterval = (DateTime.Now.Month - lastEyeCheck.Month);
            }
            
            return dateInterval;
        }      
    }


}