using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTechTest.Models.Test1;
using WebTechTest.Models.Test3;

namespace WebTechTest.Services
{
    public class SetupData
    {
        private DataContext dataContext;

        public async Task CreateData(DataContext dataContext)
        {
            this.dataContext = dataContext;

            await CreateTest1Data();
        }

        private async Task CreateTest1Data()
        {

            for (var adCount = 1; adCount <= 10; adCount++)
            {
                var adGroup = new AdGroup() { Name = $"Adgroup {adCount}" };
                dataContext.Add(adGroup);
            }

            //dataContext.SaveChanges();

            for (var i = 1; i <= 1000; i++)
            {
                for (var j = 65; j <= 89; j++)
                {
                    var id = string.Concat(Encoding.ASCII.GetString(new byte[] { (byte)j, 32 }), i);
                    var name = $"{id} Name";
                    var surname = $"{id} Surname";

                    var person = new Person() { Name = name, Surname = surname };

                    dataContext.Add(person);
                    //dataContext.SaveChanges();

                    var adGroups = dataContext.AdGroups
                                              .OrderBy(n => Guid.NewGuid())
                                              .Take(2)
                                              .Select(n => new PersonAdGroup() { AdGroupId = n.Id, PersonId = person.Id });

                    dataContext.PeopleAdGroups.AddRange(adGroups);
                    //dataContext.SaveChanges();
                }
            }

            await dataContext.SaveChangesAsync();
        }


        public void CreateTestData3()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomMark = new Random();
            var randomCourses = new Random();
            var courses = new List<Course>();
            var evaluations = new List<Evaluation>();

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
                    var evaluation = new Evaluation()
                    {
                        Name = $"Evaluation {evaluationCount}",
                        Mark = randomMark.Next(20,100)
                    };
                    evaluations.Add(evaluation);
                }
                student.Courses.AddRange(dataContext.Courses
                                              .Take(randomCourses.Next(1,50))
                                              .Select(n => new Course() { Name = n.Name, Group = n.Group }));
                dataContext.Students.Add(student);

            }



        }
    }
}
