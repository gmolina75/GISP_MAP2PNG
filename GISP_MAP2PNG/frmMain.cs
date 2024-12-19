using DATAMAP;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GISP_MAP2PNG
{
    public partial class frmMain : Form
    {
        string[] args = null;
        bool autoclose = false;
        bool saved = false;
        string filename = "";
        public frmMain()
        {
            InitializeComponent();


         
          
            ///
        }
        private async Task SaveMapAsync()
        {
            try
            {
                if (MainMap?.IsDisposed != false)
                    return;

                await Task.Delay(5000);
                if (MainMap?.IsDisposed != false)
                    return;
                if (saved)
                    return;
                using (var tmpImage = MainMap.ToImage())
                {
                    if (tmpImage != null)
                    {
                        if (File.Exists(filename))
                            File.Delete(filename);
                        tmpImage.Save(filename);
                        saved = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el mapa: {ex.Message}");
                CloseForm();
            }
        }
        //public bool saveMap()
        //{
        //    try
        //    {
        //        if(MainMap==null || MainMap.IsDisposed )
        //        {
        //            return false;
        //        }
        //        Thread.Sleep(5000);
        //        if (MainMap == null || MainMap.IsDisposed)
        //        {
        //            return false;
        //        }
        //        Image tmpImage = MainMap.ToImage();
        //        if (tmpImage != null)
        //        {
        //            using (tmpImage)
        //            {
        //                filename = args[2];
        //                if(File.Exists(filename))
        //                    File.Delete(filename);
        //                tmpImage.Save(filename);
        //                return true;
        //                //string base64 = ClsImgConvert.imagePathTobase64(filename);
        //                //Console.WriteLine(base64);
        //                //System.Diagnostics.Debug.WriteLine(base64);

        //            }
        //        }
        //        //Thread.Sleep(5000);
        //    }
        //    catch (Exception)
        //    {


        //    }
        //    return false;
        //}

        private void ConfigureMap()
        {
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.Position = new PointLatLng(ClsValida.DVal(args[0]), ClsValida.DVal(args[1]));
            MainMap.MinZoom = 1;
            MainMap.MaxZoom = 24;
            MainMap.Zoom = 15;

            var markersOverlay = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.blue_small);

            if (args.Length >= 5)
            {
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = args[4];
            }

            markersOverlay.Markers.Add(marker);
            MainMap.Overlays.Add(markersOverlay);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                args = Environment.CommandLine.Split('/').Skip(1).ToArray();
                if (args.Length < 3)
                {
                    Console.WriteLine("No hay suficientes argumentos.");
                    CloseForm();
                    return;
                }

                ConfigureMap();

                filename = args[2];
                autoclose = args.Length > 3 && args[3] == "autoclose";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                CloseForm();
            }
        }
        private void CloseForm()
        {
            if (!IsDisposed)
            {
                this.Close();
            }
        }

        // loader end loading tiles
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {

            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = async delegate ()
            {
                if (!IsDisposed)
                {
                    if(!saved)
                        await SaveMapAsync();

                    CloseForm();
                      
                    
                  
                }
                //panelMenu.Text = "Menu, Carga en " + MainMap.ElapsedMilliseconds + "ms";

                //textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00} MB de {1:0.00} MB", MainMap.Manager.MemoryCache.Size, MainMap.Manager.MemoryCache.Capacity);
            };
            try
            {
                BeginInvoke(m);
            }
            catch
            {
                CloseForm();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //SaveMapAsync();
        }
    }
}
