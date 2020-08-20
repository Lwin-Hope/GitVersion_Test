using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public Visibility Aiv2RetrieveFileStatusVisibility
        {
            get
            {
                try
                {
                    return this.RetrieveFileAdapters[1] ? Visibility.Visible : Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    return Visibility.Hidden;
                }
            }
        }

        private ObservableCollection<bool> _retrieveFileAdapters = new ObservableCollection<bool>();
        public ObservableCollection<bool> RetrieveFileAdapters
        {
            get
            {
                return _retrieveFileAdapters;
            }
            set 
            {
                if (value != this._retrieveFileAdapters)
                {
                    this._retrieveFileAdapters = value;
                    OnPropertyRaised("RetrieveFileAdapters");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            //this.RetrieveFileAdapters.CollectionChanged += 

            this.RetrieveFileAdapters.Add(true);
            this.RetrieveFileAdapters.Add(true);

           

            this.DataContext = this;


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.RetrieveFileAdapters[1] = !(this.RetrieveFileAdapters[1]);

            MessageBox.Show(this.RetrieveFileAdapters[1].ToString());
        }
    }
    
}
