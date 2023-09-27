using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageEmployeesDBApplication.Model.Data;

namespace ManageEmployeesDBApplication.Model
{
    internal static class DataWorker
    {
        // получить все отделы
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        // получить все позиции
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }

        // получить всех сотрудников
        public static List<User> GetAllUsers()
        {
            using (var db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        // создать сотрудника
        public static string CreateUser(string name, string surname, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isCheckedExist =
                    db.Users.Any(x => x.Name == name && x.Surname == surname && x.Position == position);
                if (!isCheckedExist)
                {
                    User user = new User()
                    {
                        Name = name,
                        Surname = surname,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // создать департамент
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isCheckedExist = db.Departments.Any(x => x.Name == name);
                if (!isCheckedExist)
                {
                    Department department = new Department() { Name = name };
                    db.Departments.Add(department);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // создать позицию
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isCheckedExist = db.Positions.Any(x => x.Name == name && x.Salary == salary);
                if (!isCheckedExist)
                {
                    Position position = new Position()
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };
                    db.Positions.Add(position);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // удалить сотрудника
        public static string DeleteUser(User user)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Выполнено! Сотрудник " + user.Name + "уволен.";
            }
            return result;
        }

        // удалить департамент
        public static string DeleteDepartment(Department department)
        {
            string result = "Такого департамента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = "Выполнено!Департамент " + department.Name + "удалён.";
            }
            return result;
        }

        // удалить позицию
        public static string DeletePostion(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = "Выполнено!Позиция " + position.Name + "удалена.";
            }

            return result;
        }


        // редактировать сотрудника
        public static string EditUser(User oldUser, string newName, string newSurname, string newPhone,
            Position newPosition)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(d => d.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.Surname = newSurname;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = "Выполнено!сотрудник " + user.Name + "изменён.";
                }
            }
            return result;
        }

        // редактировать департамент
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого департамента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                if (department != null)
                {
                    department.Name = newName;
                    db.SaveChanges();
                    result = "Выполнено!Департамент " + department.Name + "изменён.";
                }
            }
            return result;
        }

        // редактировать позицию
        public static string EditPostion(Position oldPosition, string newName, decimal newSalary, int newMaxNumber, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(d => d.Id == oldPosition.Id);
                if (position != null)
                {
                    position.Name = newName;
                    position.Salary = newSalary;
                    position.MaxNumber = newMaxNumber;
                    position.DepartmentId = newDepartment.Id;
                    db.SaveChanges();
                    result = "Выполнено!Позиция " + position.Name + "изменена.";
                }
            }

            return result;
        }

    }
}
