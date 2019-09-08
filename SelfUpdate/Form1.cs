using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SelfUpdate
{
    public partial class Form1 : Form
    {
        /*[DllImport("SelfUpdate.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr BeginUpdateResourse(
            [In] string pFileName,
            [In] bool bDeleteExistingResources
            );
        [DllImport("SelfUpdate.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UpdateResource(
            [In] IntPtr hUpdate,
            [In] IntPtr lpType,
            [In] IntPtr lpName,
            [In] ushort wLanguage,
            [In, Optional] string lpData,
            [In] int cbData
            );
        [DllImport("SelfUpdate.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EndUpdateResource(
            [In] IntPtr hUpdate,
            [In] bool fDiscard
            );

        static readonly IntPtr VERSION_INFO_ID = (IntPtr)16;
        static readonly IntPtr VERSION_NAME_ID = (IntPtr)1;
        const ushort VERSION_LANG_ID = 4105;*/

        public Form1()
        {
            InitializeComponent();


            var CurrentVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;

            var Args = Environment.GetCommandLineArgs();
            foreach (var Argument in Args)
                if (Argument == "ShowVersion")
                    ShowVersion(CurrentVersion);
            textBox_Version.Text = CurrentVersion;
        }

        private void ShowVersion (string CurrentVersion)
        {
            MessageBox.Show("Версия программы " + CurrentVersion);
            Environment.Exit(1);
        }

        private void Renovate_Click(object sender, EventArgs e)
        {
            try
            {
                var FilePath = Path.GetDirectoryName(Application.ExecutablePath);
                var FileName = Path.GetFileName(Application.ExecutablePath);
                var Exten = Path.GetExtension(Application.ExecutablePath);
                var OldFile = Path.GetFileNameWithoutExtension(Application.ExecutablePath) + "_old"+Exten;   
                
                if (File.Exists(String.Format("{0}\\new\\{1}", FilePath, FileName)))
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = String.Format("/c ping localhost & del {0} ", String.Format("{0}\\new\\{1}", FilePath, FileName)),
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe"
                    });

                File.Move(Application.ExecutablePath, String.Format("{0}\\new\\{1}", FilePath, FileName));
                File.Copy(String.Format("{0}\\new\\{1}", FilePath, FileName), Application.ExecutablePath);
                File.Copy(Application.ExecutablePath, OldFile);



                /*IntPtr hRes = BeginUpdateResourse(String.Format("{0}\\new\\{1}", FilePath, FileName), false);
                bool result = false;
                if (hRes == IntPtr.Zero) return;
                result = UpdateResource(hRes, VERSION_INFO_ID, VERSION_NAME_ID, VERSION_LANG_ID, "Hello", 10);
                if (!result) MessageBox.Show(String.Format("Error = "+Marshal.GetLastWin32Error()));
                if (!EndUpdateResource(hRes, false)) MessageBox.Show(String.Format("Error = "+Marshal.GetLastWin32Error()));*/

                

                Process.Start(new ProcessStartInfo()
                {
                    Arguments = String.Format("/c ping localhost & del {0} & start {1}", OldFile, Application.ExecutablePath),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName="cmd.exe"
                });
                Environment.Exit(1);
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка: " + err.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
