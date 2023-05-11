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
        private const string Icon = "🕑";

        private readonly Brush _normalBackground = new SolidColorBrush(Colors.Transparent);
        private readonly Brush _hoverBackground = new SolidColorBrush(Colors.White) { Opacity = 0.2 };

        public StatusbarControl()
        {
            Text = Icon;
            Foreground = new SolidColorBrush(Colors.White);
            Background = _normalBackground;

            VerticalAlignment = VerticalAlignment.Center;
            Margin = new Thickness(7, 0, 7, 0);
            Padding = new Thickness(7, 0, 7, 0);

            MouseEnter += (s, e) =>
            {
                Cursor = Cursors.Hand;
                Background = _hoverBackground;
            };

            MouseLeave += (s, e) =>
            {
                Cursor = Cursors.Arrow;
                Background = _normalBackground;
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
            Text = string.IsNullOrEmpty(text) ? Icon : $"{Icon} {text}";
        }

        public void SetToolTip(string toolTip)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            ToolTip = toolTip;
        }
    }
}
