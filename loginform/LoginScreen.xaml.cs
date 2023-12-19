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
using System.Windows.Shapes;

namespace loginform
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;

            using (UserContext context = new UserContext())
            {
                bool userfound = context.Users.Any(user => user.UserName == Username && user.Password == Password);

                if (userfound)
                {
                    GrantAccess();
                    Close();
                } else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль!");
                }
            }
        }

        public void GrantAccess()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
