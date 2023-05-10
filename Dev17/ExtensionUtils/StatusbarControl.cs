// Source:
// https://github.com/madskristensen/ShowTheShortcut/blob/36f90b1a6d5a09d006b8665564bf12c28416d56c/src/StatusbarControl.cs

using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WakaTime.ExtensionUtils
{
    internal class StatusbarControl : TextBlock
    {
        public StatusbarControl()
        {
            Text = "🕑";
            Foreground = new SolidColorBrush(Colors.White);
            VerticalAlignment = VerticalAlignment.Center;
            Margin = new Thickness(6, 0, 6, 0);

            MouseEnter += (s, e) =>
            {
                Cursor = Cursors.Hand;
            };

            MouseLeave += (s, e) =>
            {
                Cursor = Cursors.Arrow;
            };

            MouseLeftButtonUp += (s, e) =>
            {
                // Open WakaTime in browser
                System.Diagnostics.Process.Start("https://wakatime.com/");
            };
        }

        public void SetText(string text)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            Text = string.IsNullOrEmpty(text) ? "🕑" : $"🕑 {text}";
        }

        public void SetToolTip(string toolTip)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            ToolTip = toolTip;
        }
    }
}
