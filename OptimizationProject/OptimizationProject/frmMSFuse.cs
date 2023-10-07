using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SolverFoundation.Services;

namespace OptimizationProject
{
    public partial class frmMSFuse : Form
    {
        public frmMSFuse()
        {
            InitializeComponent();
        }

        private void btnMSFuse_Click(object sender, EventArgs e)
        {
            var solver = SolverContext.GetContext();
            var model = solver.CreateModel();
            //Add decision variables.
            var decisionX = new Decision(Domain.IntegerNonnegative, "X");
            var decisionY = new Decision(Domain.IntegerNonnegative, "Y");
            model.AddDecision(decisionX);
            model.AddDecision(decisionY);
            //Add the objective or goal.
            model.AddGoal("Goal", GoalKind.Maximize, -2 * decisionX + 5 * decisionY);
            //Add constraints or subject to.
            model.AddConstraint("Constraint0", 100 <= decisionX);
            model.AddConstraint("Constraint1", decisionX <= 200);
            model.AddConstraint("Constraint2", 80 <= decisionY);
            model.AddConstraint("Constraint3", decisionY <= 170);
            model.AddConstraint("Constraint4", decisionY >= -decisionX + 200);
            //Solve and print outputs.
            var solution = solver.Solve();
            double x = decisionX.GetDouble();
            double y = decisionY.GetDouble();
            //System.Diagnostics.Trace.WriteLine("X = " + x + " y = " + y);
            lblOut.Text= ("output: X = " + x + " y = " + y);
        }
    }
}
