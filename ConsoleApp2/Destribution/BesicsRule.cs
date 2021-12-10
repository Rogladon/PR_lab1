using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace Destribution {
	public class BesicsRule {

		private InArray<double> coeff;
		public BesicsRule(InArray<double> mean1, InArray<double> cov1, InArray<double> mean2, InArray<double> cov2) {
			coeff = GetCoeff(mean1, cov1) - GetCoeff(mean2, cov2);
		}

		private InArray<double> GetCoeff(InArray<double> mean, InArray<double> covar) {
			InArray<double> cov = ILMath.pinv(covar);
			InArray<double> a = cov[0, 0];
			InArray<double> b = cov[0, 1] + cov[1, 0];
			InArray<double> c = cov[1, 1];
			InArray<double> d = -2 * cov[0, 0] * mean[0] - cov[0, 1] * mean[1] - cov[1, 0] * mean[1];
			InArray<double> e = -2 * cov[1, 1] * mean[1] - cov[0, 1] * mean[0] - cov[1, 0] * mean[0];
			InArray<double> f = cov[0, 0] * ILMath.pow(mean[0], 2) + cov[0, 1] * mean[0] * mean[1] +
				cov[1, 0] * mean[0] * mean[1] + cov[1, 1] *
				ILMath.pow(mean[1], 2) + ILMath.log(ILMath.det(covar));
			return new double[] { a.First(), b.First(), c.First(), d.First(), e.First(), f.First() };
		}
		public InArray<double> GetY(InArray<double> x) {
			double a = coeff[0].First();
			double b = coeff[1].First();
			double c = coeff[2].First();
			double d = coeff[3].First();
			double e = coeff[4].First();
			double f = coeff[5].First();
			InArray<double> D = ILMath.pow(b * x + c, 2) - 4 * c * (a * ILMath.pow(x, 2) + d * x + f);
			if (D < 0) return new double[] { double.NaN, double.NaN };
			InArray<double> y1 = (-(b * x + c) + ILMath.sqrt(D)) / (2 * c);
			InArray<double> y2 = (-(b * x + c) - ILMath.sqrt(D)) / (2 * c);
			return new double[] { y1.First(), y2.First() };
		}
		private Func<InArray<double>, InArray<double>> GetFuncY(InArray<double> mean1, InArray<double> cov1, InArray<double> mean2, InArray<double> cov2) {
			return new BesicsRule(mean1, cov1, mean2, cov2).GetY;
		}
		public static BesicsRule Simple(NormalDestribution2Dim normal1, NormalDestribution2Dim normal2) {
			return new BesicsRule(normal1.Mean, normal1.Cov, normal2.Mean, normal2.Cov);
		}
	}
}
