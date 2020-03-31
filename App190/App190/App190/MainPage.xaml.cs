using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App190
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<myViewModel> employees { get; set; }
        public MainPage()
        {
            InitializeComponent();

            employees = new ObservableCollection<myViewModel>();
            myListView.ItemsSource = employees;

            //Mr. Mono will be added to the ListView because it uses an ObservableCollection
            employees.Add(new myViewModel() { Name = "Mr. Mono", isComplete = true });
            employees.Add(new myViewModel() { Name = "Ms. Mosssss", isComplete = false });
            employees.Add(new myViewModel() { Name = "Mr. Mssssssddono", isComplete = true });

        }

        class myViewModel : INotifyPropertyChanged
        {
            string name { get; set; }

            bool _isComplete { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            public myViewModel()
            {
            }

            public string Name
            {
                set
                {
                    if (name != value)
                    {
                        name = value;

                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                        }
                    }
                }
                get
                {
                    return name;
                }
            }

            public bool isComplete
            {
                set
                {
                    if (_isComplete != value)
                    {
                        _isComplete = value;

                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("isComplete"));
                        }
                    }
                }
                get
                {
                    return _isComplete;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            myViewModel viewModel = employees[0] as myViewModel;
            viewModel.isComplete = !viewModel.isComplete;
        }
    }

    public class myValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((bool)value == true)
            {
                return "Completed";
            }

            return "unCompleted";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return "Completed";
            }

            return "unCompleted";
        }
    }
}
