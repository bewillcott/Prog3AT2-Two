/*
 *  File Name:   MainWindow.xaml.cs
 *
 *  Copyright (c) 2021 Bradley Willcott
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ****************************************************************
 * Name: Bradley Willcott
 * ID:   M198449
 * Date: 16/08/2021
 * ****************************************************************
 */

namespace Prog3AT2_Two
{
    using MyNETCoreLib;

    using MyWpfNETCoreLib;

    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The log console
        /// </summary>
        private readonly LogConsole logConsole;

        /// <summary>
        /// The balanced binary sorted tree.
        /// </summary>
        private readonly ObservableAvlTree<string> theTree;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            theTree = new();
            InitializeComponent();
            DataContext = this;
            NamesListBox.ItemsSource = theTree;

            // Disable buttons
            AddButton.IsEnabled = false;
            RemoveButton.IsEnabled = false;
            SearchButton.IsEnabled = false;

            // Setup logging console
            logConsole = new();
        }

        /// <summary>
        /// Handles the Click event of the AddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var text = NameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(text))
            {
                theTree.Add(text);
                NameTextBox.Clear();
                NameTextBox.Focus();
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the NamesListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void NamesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RemoveButton.IsEnabled = NamesListBox.SelectedIndex > -1;
        }

        /// <summary>
        /// Handles the TextChanged event of the NameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var text = textBox.Text.Trim();

            AddButton.IsEnabled = SearchButton.IsEnabled = text.Length > 0;
        }

        /// <summary>
        /// Handles the Click event of the RemoveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NamesListBox.SelectedItem as string;

            theTree.Remove(name);
        }

        /// <summary>
        /// Handles the Click event of the SearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var text = NameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(text))
            {
                var index = theTree.IndexOf(text);
                NamesListBox.SelectedIndex = index;

                if (index > -1)
                {
                    NameTextBox.Clear();
                    NameTextBox.Focus();
                }
            }
        }

        private void DebugCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            logConsole.Hide();
        }

        private void DebugCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            logConsole.Show();
        }
    }
}