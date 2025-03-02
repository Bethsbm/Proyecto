﻿using BL.Technology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TechnologyIndustries
{
    public partial class ReporteVentasForm : Form
    {
        public ReporteVentasForm()
        {
            InitializeComponent();

            var _facturaBL = new FacturaBL();
            var bindingSource = new BindingSource();

            bindingSource.DataSource = _facturaBL.ObtenerFacturas();

            var reporte = new ReporteVentas();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
