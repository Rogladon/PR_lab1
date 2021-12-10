using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;
using ILNumerics.Toolboxes;
using System.Windows.Forms;
using Plot;
using TextParser;
using Extentions;
using Destribution;
using ILNumerics.Core;
using ILNumerics.Drawing.Plotting;
using static ILNumerics.Globals;
using System.Drawing;

namespace ConsoleApp2 {
    class Program {
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Task3();
			Console.ReadKey();
        }
		private static void Task3() {
			Array<double> iris = new ParseIris(ParseIris.TypeIris.VI, 2).ParseIOToArray("iris.txt").ToArray();
			NormalDestribution normal = NormalDestribution.Simple(iris);

			Array<double> x = ILMath.linspace(-1+ iris.mean().First(), 1 + iris.mean().First(), 20);

			Array<double> probsMean = Likelihood(iris, x, d => d, d => normal.Std);

			Console.WriteLine($"Expected mean: \n{normal.Mean}");
			Array<double> bestMean = probsMean[":;0"].max().First();
			Array<double> bestProb = probsMean[":;1"].max().First();
			Console.WriteLine($"Best mean: {bestMean}\nBest prob: {bestProb}");
			new Plot2d().Add(x, probsMean[":;1"]).SetName("Mean").Draw();

			x = ILMath.linspace(0,2, 20);

			var probsStd = Likelihood(iris, x, d => bestMean.First(), d => d);

			InArray<double> bestStd = 0;
			InArray<double> bestProbStd = 0;
			for (int i = 0; i < probsStd.Length; i++) {
				if (probsStd[i, 1] > bestProbStd) {
					bestProbStd = probsStd[i, 1].First();
					bestStd = probsStd[i, 0].First();
				}
			}

			Console.WriteLine($"Expected std: \n{normal.Std}");
			Console.WriteLine($"Best std: {bestStd}\nbest prob: {bestProbStd}");
			new Plot2d().Add(x, probsStd[":;1"]).SetName("Std").Draw();
		}

		private static Array<double> Likelihood(Array<double> iris, Array<double> x, 
			Func<double,double> mean, Func<double,double> std) {

			NormalDestribution normal = NormalDestribution.Simple(iris);
			Array<double> probs = new double[x.Length, 2];
			for (int i = 0; i < x.Length; i++) {
				var func = NormalDestribution.GetFuncY(mean(x[i].First()), std(x[i].First()));
				double prob = 1;
				foreach (var j in iris) {
					prob *= func(j).First();
				}
				probs[$"{i};:"] = new double[] { x[i].First(), prob };
			}
			return probs;
		}

		private static void Task1() {
			var iris = new ParseIris(ParseIris.TypeIris.VI, 2).ParseIOToArray("iris.txt");

			var normal = NormalDestribution.Simple(iris);

			Console.WriteLine($"mean: {normal.Mean}");
			Console.WriteLine($"var: {normal.Var}");

			Array<double> x = ILMath.linspace(-2 + normal.Mean, 2 + normal.Mean, 100);

			new Plot2d().Add(x, normal.GetY).Draw();
		}
		private static void Task2() {
			var irisSE = new ParseIrises(new ParseIrises.IrisDim[] {
				new ParseIrises.IrisDim(ParseIris.TypeIris.SE,1,true),
				new ParseIrises.IrisDim(ParseIris.TypeIris.SE,4)
			}).ParseIOToArray("iris.txt");
			var irisVI = new ParseIrises(new ParseIrises.IrisDim[] {
				new ParseIrises.IrisDim(ParseIris.TypeIris.VI,1, true),
				new ParseIrises.IrisDim(ParseIris.TypeIris.VI,4)
			}).ParseIOToArray("iris.txt");

			var normalSE = NormalDestribution2Dim.Simple(irisSE);
			var normalVI = NormalDestribution2Dim.Simple(irisVI);

			Task2Destribution(normalSE, "Se: ");
			Task2Destribution(normalVI, "Vi: ");

			BesicsRule besicsRule = BesicsRule.Simple(normalSE, normalVI);

			Array<double> x = ILMath.linspace(1, 8, 1000);

			new Plot2d().SetName("Besics").Add(x, besicsRule.GetY)
				.Add(new LinePlot(irisSE[full, 0], irisSE[full, 1]), new ConfigMarked(Color.Red))
				.Add(new LinePlot(irisVI[full, 0], irisVI[full, 1]), new ConfigMarked(Color.Blue))
				.Draw();
		}
		private static void Task2Destribution(NormalDestribution2Dim normal, string label) {

			InArray<double> x1 = ILMath.linspace(-10 + normal.Mean[0], 10 + normal.Mean[0], 100);
			InArray<double> x2 = ILMath.linspace(-10 + normal.Mean[1], 10 + normal.Mean[1], 100);

			Array<double> x = x1.Concat(x2).ToArray();
			x = x.Reshape(x.Length / 2, 2);

			new Plot3d().SetName($"{label} Plot3d")
				.Add(x.transpose(), normal.GetZ).Draw();
			Console.WriteLine($"{label} mean: \n{normal.Mean}");
			Console.WriteLine($"{label} cov: \n{normal.Cov}");
		}
	}

    

}
