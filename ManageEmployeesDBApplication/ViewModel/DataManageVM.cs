using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageEmployeesDBApplication.Model;

namespace ManageEmployeesDBApplication.ViewModel
{
    internal class DataManageVM : INotifyPropertyChanged
    {
        //все отделы
        private List<Department> allDepartments = DataWorker.GetAllDepartments();
        public List<Department> AllDepartments
        {
            get
            {
                return allDepartments;
            }
            set
            {
                allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        private List<Position> allPositions = DataWorker.GetAllPositions();
        public List<Position> AllPositions
        {
            get
            {
                return allPositions;
            }
            set
            {
                allPositions = value;
                NotifyPropertyChanged("AllPositions");
            }
        }

        private List<Position> allUsers = DataWorker.GetAllPositions();
        public List<Position> AllUsers
        {
            get
            {
                return allUsers;
            }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
