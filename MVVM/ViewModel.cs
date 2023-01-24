using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> ComboChange
        {
            get
            {
                return Model.dataList;
            }
        }

        int cbIndex;
        public int IndexSelected
        {
            set
            {
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }
    }
}
