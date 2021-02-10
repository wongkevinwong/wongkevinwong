using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTechTest.Models.Test1;
using WebTechTest.Models.Test3;

namespace WebTechTest.Services
{
    public class SetupData
    {
        private DataContext dataContext;

        public void CreateData(DataContext dataContext)
        {
            this.dataContext = dataContext;

            CreateTest1Data();
        }

        private void CreateTest1Data()
        {

            for (var adCount = 1; adCount <= 10; adCount++)
            {
                var adGroup = new AdGroup() { Name = $"Adgroup {adCount}" };
                dataContext.Add(adGroup);
            }

            dataContext.SaveChanges();

            for (var i = 1; i <= 1000; i++)
            {
                for (var j = 65; j <= 89; j++)
                {
                    string id = string.Concat(Encoding.ASCII.GetString(new byte[] { (byte)j, 32 }), i);
                    string name = $"{id} Name";
                    string surname = $"{id} Surname";

                    var person = new Person() { Name = name, Surname = surname };

                    dataContext.Add(person);
                    dataContext.SaveChanges();

                    var adGroups = dataContext.AdGroups
                                              .OrderBy(n => Guid.NewGuid())
                                              .Take(2)
                                              .Select(n => new PersonAdGroup() { AdGroupId = n.Id, PersonId = person.Id });

                    dataContext.PeopleAdGroups.AddRange(adGroups);
                    dataContext.SaveChanges();
                }
            }

            dataContext.SaveChanges();
        }


        public void CreateTestData3()
        {
            var random = new Random(DateTime.Now.Millisecond);

            var courses = new List<Course>();

            for (var courseCount = 1; courseCount <= 50; courseCount++)
            {                
                var course = new Course() { Name = $"Course {courseCount}", Group = $"Group {courseCount % 3}" };
                dataContext.Courses.Add(course);
                dataContext.SaveChanges();
            }

            for (var studentCount = 1; studentCount <= 10000; studentCount++)
            {
                var student = new Student()
                {
                    Firstname = $"Firstname {studentCount}",
                    Lastname = $"Lastname {studentCount}",
                    MiddleName = $"Middlename {studentCount}",
                    DateOfBirth = new DateTime(),
                    Gender = studentCount % 2 == 0 ? 'M' : 'F'
                };

                for (var evaluationCount = 1; evaluationCount <= 8; evaluationCount++)
                {
                }

            }


        }
    }
}
