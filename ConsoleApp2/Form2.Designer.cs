
namespace ConsoleApp2 {
	partial class Form2 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.panel1 = new ILNumerics.Drawing.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Editor = null;
			this.panel1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("panel1.Rectangle")));
			this.panel1.RendererType = ILNumerics.Drawing.RendererTypes.OpenGL;
			this.panel1.ShowUIControls = false;
			this.panel1.Size = new System.Drawing.Size(775, 425);
			this.panel1.TabIndex = 0;
			this.panel1.Timeout = ((uint)(0u));
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}

		#endregion

		private ILNumerics.Drawing.Panel panel1;
	}
}