using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace WordClassifier {
	class MainClass {

		public static string FILE_PATH = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Desktop), "italian.txt");

		public static void Main (string [] args) {

			Dictionary<string, double> points = File
  				.ReadLines (FILE_PATH)
				.Where (line => !string.IsNullOrEmpty (line)) // you may want to filter out empty lines
				.Select (line => new {
					word = line,
					unique = line.Distinct ().Count (),
					total = line.Length
				})
  				.ToDictionary (item => item.word,
					item => 15 * Math.PI * item.unique * item.unique / item.total);

			var TopTen = points
   				.OrderByDescending (pair => pair.Value)
				.ThenBy (pair => pair.Key)
				.Take (30)
				.Select (pair => $"Word: {pair.Key} Points: {pair.Value}");

			Console.Write (String.Join (Environment.NewLine, TopTen));
		}
	}


}
