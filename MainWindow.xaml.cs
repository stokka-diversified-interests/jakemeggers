using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Test
{
    // Test project CRUD form using WPF --Jacob Meggers 07-27-2023
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
            set_readOnly();
            dg_Employees_tbl.SelectedIndex = 0;
        }

        //
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Employees");
                sda.Fill(dt);
                dg_Employees_tbl.ItemsSource = dt.DefaultView;
            }
        }

        private void dg_Employees_tbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView? selected_row = dg.SelectedItem as DataRowView;

            if (selected_row != null)
            {
                tb_lastname.Text = selected_row["LastName"].ToString();
                tb_firstname.Text = selected_row["FirstName"].ToString();
                tb_title.Text = selected_row["Title"].ToString();
                tb_prefix.Text = selected_row["TitleOfCourtesy"].ToString();
                dp_dob.Text = selected_row["BirthDate"].ToString();
                dp_hiredate.Text = selected_row["HireDate"].ToString();
                tb_address.Text = selected_row["Address"].ToString();
                tb_city.Text = selected_row["City"].ToString();
                tb_state.Text = selected_row["Region"].ToString();
                tb_zip.Text = selected_row["PostalCode"].ToString();
                tb_country.Text = selected_row["Country"].ToString();
                tb_homephone.Text = selected_row["HomePhone"].ToString();
                tb_extension.Text = selected_row["Extension"].ToString();
                tb_notes.Text = selected_row["Notes"].ToString();
            }

            set_readOnly();
        }

        private void set_readOnly()
        {
            tb_lastname.IsEnabled = false;
            tb_firstname.IsEnabled = false;
            tb_title.IsEnabled = false;
            tb_prefix.IsEnabled = false;
            tb_address.IsEnabled = false;
            tb_city.IsEnabled = false;
            tb_state.IsEnabled = false;
            tb_zip.IsEnabled = false;
            tb_country.IsEnabled = false;
            tb_homephone.IsEnabled = false;
            tb_extension.IsEnabled = false;
            tb_notes.IsEnabled = false;
            dp_dob.IsEnabled = false;
            dp_hiredate.IsEnabled = false;
         }

        private void set_editable()
        {
            tb_lastname.IsEnabled = true;
            tb_firstname.IsEnabled = true;
            tb_title.IsEnabled = true;
            tb_prefix.IsEnabled = true;
            tb_address.IsEnabled = true;
            tb_city.IsEnabled = true;
            tb_state.IsEnabled = true;
            tb_zip.IsEnabled = true;
            tb_country.IsEnabled = true;
            tb_homephone.IsEnabled = true;
            tb_extension.IsEnabled = true;
            tb_notes.IsEnabled = true;
            dp_dob.IsEnabled = true;
            dp_hiredate.IsEnabled = true;
        }



        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            set_editable();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_apply_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
