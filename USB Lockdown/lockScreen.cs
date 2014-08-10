using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace USB_Lockdown
{
    public partial class lockScreen : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public lockScreen()
        {
            InitializeComponent();
            KeyboardLock.enable();
            setupWindow();

        }



        private void setupWindow()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = SystemInformation.VirtualScreen.Height;
            this.Width = SystemInformation.VirtualScreen.Width;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SetForegroundWindow(this.Handle);
            this.ShowInTaskbar = false;
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) { e.Cancel = true; } //disables alt+F4
        }

        private void keepForeground(object sender, EventArgs e) { SetForegroundWindow(this.Handle); }
    }
}
