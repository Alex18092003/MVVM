using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string NumberOne
        {
            get { return Model.OneNumber; }
            set { Model.OneNumber = value; }
        }

        public string NumberTwo
        {
            get { return Model.TwoNumber; }
            set { Model.TwoNumber = value; }
        }
        public string Result
        {
            get { return Model.textResult.ToString(); }
        }

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

        public string CBIndex 
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

        // обработчик события для Command 
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            double numberOne = Convert.ToDouble(Model.OneNumber);
            double numberTwo = Convert.ToDouble(Model.TwoNumber);
 
                switch (cbIndex)
                {
                    case 0:
                        Model.textResult = Convert.ToString(numberOne + numberTwo);
                        break;
                    case 1:
                        Model.textResult = Convert.ToString(numberOne - numberTwo);
                        break;
                    case 2:
                        Model.textResult = Convert.ToString(numberOne * numberTwo);
                        break;
                    case 3:
                        Model.textResult = Convert.ToString(numberOne / numberTwo);
                        break;
                }
            
            
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
