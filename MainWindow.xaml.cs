using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsRecoveryy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                Process.Start(new ProcessStartInfo(Environment.ProcessPath) { Verb = "runas", UseShellExecute = true });
                this.Close();
                return;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // HKCU — ограничения текущего пользователя
            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableCMD", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoControlPanel", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoFolderOptions", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoRun", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoClose", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoLogOff", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoChangeStartMenu", 0, RegistryValueKind.DWord);

            Registry.CurrentUser.CreateSubKey(
                @"Software\Policies\Microsoft\Windows\System"
            ).SetValue("DisableCMD", 0, RegistryValueKind.DWord);

            // HKLM — ограничения для всех пользователей (требуются права администратора)
            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System"
            ).SetValue("DisableCMD", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoControlPanel", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoFolderOptions", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"
            ).SetValue("NoRun", 0, RegistryValueKind.DWord);

            Registry.LocalMachine.CreateSubKey(
                @"Software\Policies\Microsoft\Windows\System"
            ).SetValue("DisableCMD", 0, RegistryValueKind.DWord);

            MessageBox.Show("Разблокированно через метод Registry.LocalMachine.CreateSubKey");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registry.LocalMachine.CreateSubKey(
            @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"
            )?.SetValue("DisableWindowsUpdateAccess", 1, RegistryValueKind.DWord);
            MessageBox.Show("Windows Update был выключен");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Registry.LocalMachine.CreateSubKey(
            @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate"
            )?.SetValue("DisableWindowsUpdateAccess", 0, RegistryValueKind.DWord);
            MessageBox.Show("Windows Update был включён");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            modules windoww = new modules();
            windoww.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Registry.LocalMachine.CreateSubKey(@"SYSTEM\Setup").SetValue("CmdLine", "", RegistryValueKind.String);
            MessageBox.Show("Cmdline был удалён");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Registry.LocalMachine.CreateSubKey(@"SYSTEM\Setup").SetValue("CmdLine", "cmd.exe", RegistryValueKind.String);
            MessageBox.Show("Cmdline был заменён на cmd.exe");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Process.Start("files/kvrt.exe");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Process.Start("files/warp.msi");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Process.Start("files/sysinfo/SystemInformer.exe");
        }
    }
}