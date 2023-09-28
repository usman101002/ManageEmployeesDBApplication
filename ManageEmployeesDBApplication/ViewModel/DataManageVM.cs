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
