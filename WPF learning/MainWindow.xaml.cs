using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using WPF_learning.Models;
using WPF_learning.Services;

namespace WPF_learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<TodoModel> TodoDataList;
        private FileIOService FileIOService;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.FileIOService = new FileIOService(PATH);

            try
            {
                this.TodoDataList = FileIOService.LoadData();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                this.Close();
            }


            this.dgTodoList.ItemsSource = TodoDataList;
            this.TodoDataList.ListChanged += TodoDataList_ListChanged;
        }

        private void TodoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    FileIOService.SaveData(sender);
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                    this.Close();

                }
            }
        }
    }
}