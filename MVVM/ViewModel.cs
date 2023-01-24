using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

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

        int cbIndex = -1;
        public int IndexSelected
        {
            set
            {
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }

        public string CBIndex // свойство для отображения фамилии в Combobox
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataListOperation[cbIndex];
                }

            }
        }

        // класс, который реализазует интерфейс ICommand
        public RoutedCommand Command { get; set; } = new RoutedCommand();

        // обработчик события для Command (увеличение значения числа на 1)
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Model.count++;
            PropertyChanged(this, new PropertyChangedEventArgs("CountChange"));
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            //bind.Execute += Command_Executed;
        }
    }
}
