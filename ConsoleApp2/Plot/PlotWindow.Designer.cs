
namespace Plot {
	partial class PlotWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotWindow));
			this.panel = new ILNumerics.Drawing.Panel();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Editor = null;
			this.panel.Location = new System.Drawing.Point(12, 12);
			this.panel.Name = "panel";
			this.panel.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("panel.Rectangle")));
			this.panel.RendererType = ILNumerics.Drawing.RendererTypes.OpenGL;
			this.panel.ShowUIControls = false;
			this.panel.Size = new System.Drawing.Size(776, 426);
			this.panel.TabIndex = 0;
			this.panel.Timeout = ((uint)(0u));
			// 
			// PlotWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel);
			this.Name = "PlotWindow";
			this.Text = "PlotWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private ILNumerics.Drawing.Panel panel;
	}
}