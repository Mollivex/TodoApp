using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using TodoApp.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using TodoApp.Services;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Path to .json file near .EXE executive file
        /// </summary>
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";

        /// <summary>
        /// Data container(list) for Models
        /// </summary>
        private BindingList<TodoModel> _todoDataList;

        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                // the operation of accessing to hard disk where data is stored using _fileIOService service
                _todoDataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }


            dgTodoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoData_ListChanged;
        }

        private void _todoData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged )
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }
    }
}
