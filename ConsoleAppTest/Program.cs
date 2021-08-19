/*
 *  File Name:   Program.cs
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

namespace ConsoleAppTest
{
    using System;
    using System.Threading.Channels;

    using MyNETCoreLib;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        private Program()
        {
        }

        private static AvlTree<string> tree;

        /// <summary>
        /// The Main.
        /// </summary>
        public static void Main()
        {
            tree = new AvlTree<string>
            {
                "Adam Smith",
                "Xavia Renolds",
                "David Jones",
                "Tammy Mills",
                "Zoro",
                "Carmen Hills",
                "Eliza Manellie",
                "Manny Troy",
                "Gregory Whyte",
                "Mary Jones"
            };

            tree.Display();

            foreach (string item in tree)
            {
                Console.WriteLine(item);
            }

            FindIt("Adam Smith");
            FindIt("Zoro");
            FindIt("Y");

            if (tree.Delete("Tammy Mills"))
            {
                Console.WriteLine(@"Found ('Tammy Mills') and deleted!");
            }
            else
            {
                Console.WriteLine(@"'Tammy Mills' not found!");
            }

            if (tree.Delete("B"))
            {
                Console.WriteLine(@"Found ('B') and deleted!");
            }
            else
            {
                Console.WriteLine(@"'B' not found!");
            }

            tree.Display();

            var array = new string[10];

            tree.CopyTo(array, 0);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine(@"Done!");
        }

        private static void FindIt(string text)
        {
            if (tree.Contains(text))
            {
                Console.WriteLine($"Found: {text}");
            }
            else
            {
                Console.WriteLine($"Did not find: {text}");
            }
        }
    }
}