using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Core.Internal.Geometry;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Geoprocessing;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace testApp
{
    public class clsFeatureClass
    {
        public struct ItemData
        {
            public string txtID;
            public long objId;
        }
        public string layNa = string.Empty;
        public Map uMap = null;
        public static string defaultTool = "esri_mapping_exploreTool"; //returning to the default tool.

        public clsFeatureClass(string layNa, Map uMap)
        {
            this.layNa = layNa;
            this.uMap = uMap;
        }

        public static T DeepClone<T>(T obj)
        {
            T objResult;
            using (MemoryStream ms = new MemoryStream())
            {   BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;
                objResult = (T)bf.Deserialize(ms); }
            return objResult;
        }

        //return the feature layer with the given layer name.
        public static FeatureLayer setCurrentLayer(string layNa, Map uMap)
        {
            IEnumerable<Layer> uLayers = uMap.GetLayersAsFlattenedList().Where(l => l.Name==layNa);
            if (uLayers == null) return null;
            if (uLayers.Count() < 1) return null;
            FeatureLayer uLay = null;
            try
            { uLay = (FeatureLayer)uLayers.First(); }
            catch { }
            //{MessageBox.Show("Couldn't find the layer " + layNa);}
            return uLay;
        }

        //return the feature layer with the given layer name.
        public static bool IsLayerExist(Map uMap,string layNa)
        {
            IEnumerable<Layer> uLayers = uMap.GetLayersAsFlattenedList().Where(l => l.Name==layNa);
            if (uLayers == null) return false;
            if (uLayers.Count() < 1) return false;

            return true;
        }

        //return the feature layer with the given layer name.
        public static StandaloneTable setCurrentTable(Map uMap, string TableNa)
        {
            StandaloneTable uTable = null;
            IEnumerable<StandaloneTable> tables = uMap.StandaloneTables;
            foreach (StandaloneTable uLay in tables)
            {   if (uLay.Name == TableNa)
                {   uTable = uLay;
                    break;}
            }
            //if (uTable==null)
                //MessageBox.Show("Couldn't find the table " + TableNa); 
            return uTable;
        }

        public static bool IsField_Exist(string fldName, StandaloneTable uLay)
        {
            bool blnExist = false;
            RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
            if (rows == null) return false;

            rows.MoveNext();
            Row uFea = rows.Current;
            if (uFea != null)
            {   IReadOnlyList<Field> cols = uFea.GetFields();
                foreach (Field fld in cols)
                {   if (fldName == fld.Name)
                    {   blnExist = true;
                        break;}
                }
                cols = null;
                uFea.Dispose();}
            if (rows != null) rows.Dispose();

            if (!blnExist)
                MessageBox.Show("Field name [" + fldName + "] could not be found in the table " + uLay.Name);
            return blnExist;
        }

        public static bool IsField_Exist(string fldName, FeatureLayer uLay)
        {
            if (uLay == null) return false;
            bool blnExist = false;
            RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
            if (rows == null) return false;

            rows.MoveNext();
            Feature uFea = (Feature)rows.Current;
            
            if (uFea != null)
            {   IReadOnlyList<Field> cols = uFea.GetFields();
                foreach (Field fld in cols)
                {   if (fldName == fld.Name)
                    {   blnExist = true;
                        break;}
                }
                uFea.Dispose();
                cols = null; }
            if (rows != null) rows.Dispose();
            
            if (!blnExist)
                MessageBox.Show("Field name [" + fldName + "] could not be found in the layer " + uLay.Name);
            return blnExist;
        }

        public static string getObjectField_ID(FeatureLayer uLay)
        {
            string objectID_fld = "FID";//ObjectID field name for shape file.
            if (uLay.ConnectionStatus == ConnectionStatus.Broken)
                return string.Empty;
            if (uLay != null)  //If the layer source is geodatabase.
                objectID_fld = uLay.GetTable().GetDefinition().GetObjectIDField();
            return objectID_fld;
        }

        //List all field names to the dropboxes.
        public static List<string> list_Columns(string layNa, Map uMap)
        {
            List<string> flds = null;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(layNa,uMap);
                if (uLay == null) return;

                flds = new List<string>();
                RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
                if (rows == null) return;

                rows.MoveNext();
                uFea = (Feature)rows.Current;
                if (uFea != null)
                {   IReadOnlyList<Field> cols = uFea.GetFields();
                    foreach (Field fld in cols)
                        flds.Add(fld.Name);
                    //dispose the memory captured.
                    cols = null;
                    uFea.Dispose(); }
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            if (flds != null) flds.Sort();
            return flds;
        }

        //List all field names to the dropboxes.
        public static List<string> list_TableColumns(string layNa, Map uMap)
        {
            List<string> flds = null;
            Task T = QueuedTask.Run(() =>
            {   Row uFea = null;
                StandaloneTable uLay = setCurrentTable(uMap,layNa);
                if (uLay == null) return;

                flds = new List<string>();
                RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
                if (rows == null) return;

                rows.MoveNext();
                uFea = rows.Current;
                if (uFea != null)
                {   IReadOnlyList<Field> cols = uFea.GetFields();
                    foreach (Field fld in cols)
                        flds.Add(fld.Name);
                    //dispose the memory captured.
                    cols = null;
                    uFea.Dispose(); }
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            if (flds != null) flds.Sort();
            return flds;
        }

        //Select all layers loaded in the argis application.
        public static List<string> listLayers(Map uMap)
        {
            List<string> uL = new List<string>();

            IEnumerable<Layer> uLayers = uMap.GetLayersAsFlattenedList();
            foreach (Layer uLay in uLayers)
                if (uLay.GetType() == typeof(FeatureLayer))
                    uL.Add(uLay.Name);

            if (uL != null) uL.Sort();
            return uL;
        }

        //Select all layers with the given shape type loaded in the argis application.
        public static List<string> listFeatureLayers(Map uMap, esriGeometryType shpType)
        {
            List<string> uL = new List<string>();

            IEnumerable<Layer> uLayers = uMap.GetLayersAsFlattenedList();
            foreach (Layer uLay in uLayers)
            {   if (uLay.GetType() == typeof(FeatureLayer))
                {   FeatureLayer feaLay = (FeatureLayer)uLay;
                    if (feaLay.ShapeType == shpType)
                        uL.Add(uLay.Name); }
            }
            if (uL != null) uL.Sort();
            return uL;
        }

        //Select all layers with given shape types loaded in the argis application.
        public static List<string> listFeatureLayers(Map uMap,
                esriGeometryType shpType, esriGeometryType extraType)
        {
            List<string> uL = new List<string>();

            IEnumerable<Layer> uLayers = uMap.GetLayersAsFlattenedList();
            foreach (Layer uLay in uLayers)
            {   if (uLay.GetType() == typeof(FeatureLayer))
                {   FeatureLayer feaLay = (FeatureLayer)uLay;
                    if (feaLay.ShapeType == shpType || feaLay.ShapeType == extraType)
                        uL.Add(uLay.Name); }
            }
            if (uL != null) uL.Sort();
            return uL;
        }

        //Select all layers loaded in the argis application.
        public static List<string> listDataTables(Map uMap)
        {
            List<string> uL = new List<string>();

            IEnumerable<StandaloneTable> tables = uMap.StandaloneTables;
            foreach (StandaloneTable uLay in tables)
                uL.Add(uLay.Name);

            if (uL != null) uL.Sort();
            return uL;
        }

        //return the feature layer with the given layer name.
        public FeatureClass getLayerAsFeatureClass(string layNa)
        {
            FeatureLayer uLay = setCurrentLayer(layNa, uMap);
            if (uLay == null) return null;
            return uLay.GetFeatureClass();
        }

        public static double distanceXY(double x1,double y1, double x2, double y2)
        {
            double delx = x2 - x1;
            double dely = y2 - y1;
            return Math.Sqrt(delx * delx + dely * dely);
        }

        public void exportSelectedFeatures(string layname, string outputLayer)
        {
            string input_layer = layname;
            long selected_count =  getSelectedItemCount(layname, ref input_layer);

            if (selected_count < 1)
            {   MessageBox.Show("Nothing to export. Please select the features using button [Show on Map]");
                return; }

            string tool_path = "CopyFeatures_management";//"management.CopyFeatures";
            var args = Geoprocessing.MakeValueArray(input_layer, outputLayer); //Input layer first and output layer second.
            Task gp_result = Geoprocessing.ExecuteToolAsync(tool_path, args);
        }

        private int getSelectedItemCount(string layname, ref string input_layer)
        {
            string laytitle = input_layer;
            int count = 0;
            Task T= QueuedTask.Run(() =>
            {   FeatureLayer uLay = setCurrentLayer(layname, uMap);
                if (uLay != null)
                {   if (uLay.Parent.ToString() != uMap.Name)
                        laytitle = uLay.Parent + "\\" + uLay.Name;
                    else
                        laytitle = uLay.Name;
                    count = (int)uLay.GetSelection().GetCount(); }
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            input_layer = laytitle;
            return count;
        }

        //read attributes from a given layer.
        public static List<string> read_attributes(string fldNa, string layNa, Map uMap,string uCmd)
        {
            Feature uFea = null;
            FeatureLayer uLay = setCurrentLayer(layNa, uMap);
            if (uLay == null) return null;
            bool bln1 = IsField_Exist(fldNa, uLay);
            if (!bln1) return null;

            List<string> attList = new List<string>();
            var queryFilter = new QueryFilter();
            queryFilter.SubFields = fldNa;
            if (uCmd != string.Empty) queryFilter.WhereClause = uCmd;
            RowCursor rows = uLay.Search(queryFilter); //select based on the query.
            if (rows == null) return null;

            while (rows.MoveNext())
            {   uFea = (Feature)rows.Current;
                //int pos = uFea.FindField(fldNa);
                if (uFea[fldNa] != null)
                {   string attVal = uFea[fldNa].ToString().Trim();
                    if (attVal.Trim() != string.Empty)
                        attList.Add(attVal); }
            }
            if (uFea != null) uFea.Dispose();
            if (rows != null) rows.Dispose();
            uLay = null;
            return attList;
        }

        //read attributes from a given layer.
        public static List<string> read_attributes(string fldNa, FeatureLayer uLay, Map uMap, string uCmd)
        {
            Feature uFea = null;
            if (uLay == null) return null;
            bool bln1 = IsField_Exist(fldNa, uLay);
            if (!bln1) return null;

            List<string> attList = new List<string>();
            var queryFilter = new QueryFilter();
            queryFilter.SubFields = fldNa;
            if (uCmd != string.Empty) queryFilter.WhereClause = uCmd;
            RowCursor rows = uLay.Search(queryFilter); //select based on the query.
            if (rows == null) return null;

            while (rows.MoveNext())
            {   uFea = (Feature)rows.Current;
                //int pos = uFea.FindField(fldNa);
                if (uFea[fldNa] != null)
                {   string attVal = uFea[fldNa].ToString().Trim();
                    if (attVal.Trim() != string.Empty)
                        attList.Add(attVal); }
            }
            if (uFea != null) uFea.Dispose();
            if (rows != null) rows.Dispose();
            uLay = null;
            return attList;
        }

        public static bool IsFieldListOK(string[] fldNa, StandaloneTable uLay)
        {
            if (uLay == null) return false;
            bool blnExist = false;
            RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
            if (rows == null) return false;

            rows.MoveNext();
            Row uFea = rows.Current;

            if (uFea != null)
            {   blnExist = true;
                IReadOnlyList<Field> cols = uFea.GetFields();
                List<string> tblFields = new List<string>();
                foreach (Field fld in cols)
                    tblFields.Add(fld.Name);
                foreach (string fldname in fldNa)
                {   if (!tblFields.Contains(fldname))
                    {   MessageBox.Show("Field name [" + fldname + "] could not be found in table " + uLay.Name);
                        blnExist = false;
                        break; }
                }
                uFea.Dispose();
                cols = null;
            }
            if (rows != null) rows.Dispose();
            return blnExist;
        }

        public static bool IsFieldListOK(string[] fldNa, FeatureLayer uLay)
        {
            if (uLay == null) return false;
            bool blnExist = false;
            RowCursor rows = uLay.Search(); //return all rows if queryFilter is not provided.
            if (rows == null) return false;

            rows.MoveNext();
            Feature uFea = (Feature)rows.Current;

            if (uFea != null)
            {   blnExist = true;
                IReadOnlyList<Field> cols = uFea.GetFields();
                List<string> tblFields = new List<string>();
                foreach (Field fld in cols)
                    tblFields.Add(fld.Name);
                foreach (string fldname in fldNa)
                {   if (!tblFields.Contains(fldname))
                    {   MessageBox.Show("Field name [" + fldname + "] could not be found in table " + uLay.Name);
                        blnExist = false;
                        break; }
                }
                uFea.Dispose();
                cols = null;
            }
            if (rows != null) rows.Dispose();
            return blnExist;
        }

        //read and return an attribute value from a given layer.
        public static float getQuery_Value(string qryCmd, string fldNa, string layNa, Map uMap)
        {
            float qryVal = 0;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(layNa,uMap);
                if (uLay == null) return;
                bool bln1 = IsField_Exist(fldNa,uLay);
                if (!bln1) return;

                var queryFilter = new QueryFilter();
                queryFilter.WhereClause = qryCmd;
                queryFilter.SubFields = fldNa;
                RowCursor rows = uLay.Search(queryFilter); //return all rows if queryFilter is not provided.
                if (rows == null) return;
                //read first row
                rows.MoveNext();
                uFea = (Feature)rows.Current;
                if (uFea == null) return;

                qryVal = numericValue(uFea[fldNa]);
                uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return qryVal;
        }

        public static float numericValue(object d)
        {
            if (d == null) return 0;
            if (Convert.IsDBNull(d)) return 0;
            if (d.ToString() == string.Empty) return 0;

            try
            {return Convert.ToSingle(d);}
            catch { return 0; }
        }

        private static string subField_list(string[] fldNa)
        {
            if (fldNa.Length < 1) return string.Empty;

            string flds = fldNa[0];
            for (int i = 1; i < fldNa.Length; i++)
                flds += "," + fldNa[i];

            return flds;
        }

        //read attributes from a given table and return a list of comma separated string.
        public static List<string> read_attributes(string qryCmd, string[] fldNa, string TableNa, Map uMap)
        {
            List<string> attList = null; 
            Task T = QueuedTask.Run(() =>
            {   Row uFea = null;
                StandaloneTable uLay = setCurrentTable(uMap, TableNa);
                if (uLay == null) return;
                bool bln1 = IsFieldListOK(fldNa, uLay);
                if (!bln1) return;

                var queryFilter = new QueryFilter();
                queryFilter.SubFields = subField_list(fldNa);
                if (qryCmd != string.Empty) queryFilter.WhereClause = qryCmd;
                RowCursor rows = uLay.Search(queryFilter);
                if (rows == null) return;

                attList = new List<string>(); 
                while (rows.MoveNext())
                {   uFea =  rows.Current;
                    string attVal = getTextValue(uFea[fldNa[0]]);
                    for (int i = 1; i < fldNa.Length; i++)
                    {   string att1 = getTextValue(uFea[fldNa[i]]);
                        attVal += "," + att1; }
                    if (attVal.Trim() != string.Empty) attList.Add(attVal); }
                if (uFea != null) uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return attList;
        }

        //read attributes from a given layer and returns a list of comma separate string.
        public static List<string> read_Layer_attributes(string qryCmd, string[] fldNa, string LayerNa, Map uMap)
        {
            List<string> attList = null;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(LayerNa,uMap);
                if (uLay == null) return;
                bool bln1 = IsFieldListOK(fldNa, uLay);
                if (!bln1) return;
                var queryFilter = new QueryFilter();
                queryFilter.SubFields = subField_list(fldNa);
                if (qryCmd != string.Empty) queryFilter.WhereClause = qryCmd;
                RowCursor rows = uLay.Search(queryFilter);
                if (rows == null) return;

                attList = new List<string>();
                while (rows.MoveNext())
                {   uFea =(Feature)rows.Current;
                    string attVal = getTextValue(uFea[fldNa[0]]);
                    for (int i = 1; i < fldNa.Length; i++)
                    {   string att1 = getTextValue(uFea[fldNa[i]]);
                        attVal += "," + att1; }
                    if (attVal.Trim() != string.Empty) attList.Add(attVal);
                }
                if (uFea != null) uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return attList;
        }

        //read attributes from a given layer and return a list of comma separated string for selected features.
        public static List<string> read_Selected_Fea_attrbs(string qryCmd, string[] fldNa, string LayerNa, Map uMap)
        {
            List<string> attList = null;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(LayerNa, uMap);
                if (uLay == null) return;
                bool bln1 = IsFieldListOK(fldNa, uLay);
                if (!bln1) return;
                var queryFilter = new QueryFilter();
                queryFilter.SubFields = subField_list(fldNa);
                if (qryCmd != string.Empty) queryFilter.WhereClause = qryCmd;
                RowCursor rows = uLay.GetSelection().Search(queryFilter);
                if (rows == null) return;

                attList = new List<string>();
                while (rows.MoveNext())
                {   uFea = (Feature)rows.Current;
                    string attVal = getTextValue(uFea[fldNa[0]]);
                    for (int i = 1; i < fldNa.Length; i++)
                    {   string att1 = getTextValue(uFea[fldNa[i]]);
                        attVal += "," + att1; }
                    if (attVal.Trim() != string.Empty) attList.Add(attVal);
                }
                if (uFea != null) uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return attList;
        }

        //read attributes from a given layer.
        public static List<long> read_ObjectIds(string qryCmd, string LayerNa, Map uMap)
        {
            List<long> attList = null;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(LayerNa, uMap);
                if (uLay == null) return;

                string objId_fld = getObjectField_ID(uLay);
                var queryFilter = new QueryFilter();
                queryFilter.SubFields = objId_fld;
                if (qryCmd != string.Empty) queryFilter.WhereClause = qryCmd;
                RowCursor rows = uLay.Search(queryFilter);
                if (rows == null) return;

                attList = new List<long>();
                while (rows.MoveNext())
                {   uFea = (Feature)rows.Current;
                    long attVal = (long)numericValue(uFea[objId_fld]);
                    if (attVal>0) attList.Add(attVal); }
                if (uFea != null) uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return attList;
        }

        //read attributes from a given layer.
        public static List<ItemData> read_ObjectIds(string qryCmd, string fldName, string LayerNa, Map uMap)
        {
            List<ItemData> attList = null;
            Task T = QueuedTask.Run(() =>
            {   Feature uFea = null;
                FeatureLayer uLay = setCurrentLayer(LayerNa, uMap);
                if (uLay == null) return;
                bool bln1 = IsField_Exist(fldName, uLay);
                if (!bln1) return;

                string objId_fld = getObjectField_ID(uLay);
                var queryFilter = new QueryFilter();
                queryFilter.SubFields = objId_fld + "," + fldName;
                if (qryCmd != string.Empty) queryFilter.WhereClause = qryCmd;
                RowCursor rows = uLay.Search(queryFilter);
                if (rows == null) return;

                attList = new List<ItemData>();
                while (rows.MoveNext())
                {   uFea = (Feature)rows.Current;
                    ItemData itm = new ItemData();
                    itm.objId = (long)numericValue(uFea[objId_fld]);
                    itm.txtID = getTextValue(uFea[fldName]);
                    attList.Add(itm);}
                if (uFea != null) uFea.Dispose();
                if (rows != null) rows.Dispose();
                uLay = null;
            });
            T.Wait();
            T.Dispose();

            return attList;
        }

        public static string getTextValue(object d)
        {
            if (d == null) return string.Empty;
            if (Convert.IsDBNull(d)) return string.Empty;

            return Convert.ToString(d).Trim();
        }

        public static void zoom_to_Feature(string queryCmd, string layName, Map uMap)
        {
            try
            {   Task T = QueuedTask.Run(() =>
                {   FeatureLayer uLay = setCurrentLayer(layName, uMap);
                    QueryFilter uCmd = new QueryFilter();
                    uCmd.WhereClause = queryCmd;
                    uLay.Select(uCmd, SelectionCombinationMethod.Add);
                    MapView.Active.ZoomToSelected();
                    uLay = null;
                });
            }
            catch { }
        }

        public static void zoom_to_Feature(Map uMap)
        {
            try
            {   Task T = QueuedTask.Run(() =>
                {MapView.Active.ZoomToSelected();});
            }
            catch { }
        }

        public static void clearSelection(string layNa, Map uMap)
        {
            Task r = QueuedTask.Run(() =>
            {   //clear old selection.
                FeatureLayer uLay = setCurrentLayer(layNa, uMap);
                if (uLay == null) return;
                if (uLay.SelectionCount > 0) uLay.ClearSelection();
                uLay = null;
            });
        }

        // Find the polygon's centroid.
        public static PointF FindCentroid(List<PointF> polyPts, float pArea)
        {
            // Add the first point at the end of the array.
            int num_points = polyPts.Count;
            PointF[] pts = new PointF[num_points + 1];
            polyPts.CopyTo(pts, 0);
            pts[num_points] = polyPts[0];
            // Find the centroid.
            float X = 0, Y = 0;
            float second_factor;
            for (int i = 0; i < num_points; i++)
            {   second_factor = pts[i].X * pts[i + 1].Y - pts[i + 1].X * pts[i].Y;
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor; }

            // Divide by 6 times the polygon's area.
            X /= (6 * pArea);
            Y /= (6 * pArea);
            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {   X = -X;
                Y = -Y; }

            return new PointF(X, Y);
        }

        public static string qry_Field(string flds, string fld, ref bool bln, FeatureLayer uLay)
        {
            string uFlds = flds;
            bln = IsField_Exist(fld, uLay);
            if (bln)
            {   if (flds != string.Empty) uFlds = flds + "," + fld;
                else uFlds = fld; }
            return uFlds;
        }
    }
}
