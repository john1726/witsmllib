using System;
using witsmllib.util;
using System.Xml.Linq;

namespace witsmllib.v120
{

    /**
     * Version specific implementation of the WitsmlMudLog type.
     *
     * @author <a href="mailto:info@nwitsml.org">NWitsml</a>
     */

    sealed class WitsmlMudLog : witsmllib.WitsmlMudLog
    {

        /**
         * Create a new WITSML mud log instance.
         *
         * @param server    Server this instance lives within. Non-null.
         * @param id        ID of instance. May be null.
         * @param name      Name of instance. May be null.
         * @param parent    Parent of instance. May be null.
         * @param parentId  ID of parent instance. May be null.
         */
        private WitsmlMudLog(WitsmlServer server, String id, String name,
                             WitsmlObject parent, String parentId)
        
            :base(server, id, name, parent, parentId)
        {}

        /**
         * Factory method for this type.
         *
         * @param server   Server the new instance lives within. Non-null.
         * @param parent   Parent instance. May be null.
         * @param element  XML element to create instance from. Non-null.
         * @return         New WITSML wellbore instance. Never null.
         */
        static WitsmlObject newInstance(WitsmlServer server, WitsmlObject parent,
                                        XElement element)
        {
            //Debug.Assert(server != null : "server cannot be null";
            //Debug.Assert(element != null : "element cannot be null";

            String id = element.Attribute("uidMudLog").Value ;
            String parentId = element.Attribute("uidWellbore").Value;
            String name = XmlUtil.update(element, "nameMudLog", (String)null);

            WitsmlMudLog mudLog = new WitsmlMudLog(server, id, name, parent, parentId);
            mudLog.update(element);

            return mudLog;
        }

        /**
         * Return complete XML query for this type.
         *
         * @param id        ID of instance to get. May be empty to indicate all.
         *                  Non-null.
         * @param parentId  Parent IDs. Closest first. May be empty if instances
         *                  are accessed from the root. Non-null.
         * @return          XML query. Never null.
         */
        static String getQuery(String id, params String[] parentId)
        {
            //Debug.Assert(id != null : "id cannot be null";
            //Debug.Assert(parentId != null : "parentId cannot be null";

            String uidWellbore = parentId.Length > 0 ? parentId[0] : "";
            String uidWell = parentId.Length > 1 ? parentId[1] : "";

            String query = "<mudLogs xmlns=\"" + WitsmlVersion.VERSION_1_2_0.getNamespace() + "\">" +
                           "  <mudLog uidWell = \"" + uidWell + "\"" +
                           "          uidWellbore = \"" + uidWellbore + "\"" +
                           "          uidMudLog   = \"" + id + "\">" +
                           "      <nameMudLog/>" +
                           "      <dTim/>" +
                           "      <mudLogCompany/>" +
                           "      <mudLogEngineers/>" +
                           "      <startMd uom=\"" + WitsmlServer.distUom+"\"/>" +
                           "      <endMd uom=\"" + WitsmlServer.distUom+"\"/>" +
                           WitsmlCommonData.getQuery() +
                           "  </mudLog>" +
                           "</mudLogs>";

            return query;
        }

        /**
         * Parse the specified DOM element and instantiate the properties
         * of this instance.
         *
         * @param element  XML element to parse. Non-null.
         */
        private void update(XElement element)
        {
            //Debug.Assert(element != null : "element cannot be null";

            time = XmlUtil.update(element, "dTim", time);
            mudLogCompany = XmlUtil.update(element, "mudLogCompany", mudLogCompany);
            mudLogEngineers = XmlUtil.update(element, "mudLogEngineers", mudLogEngineers);
            mdStart = XmlUtil.update(element, "startMd", mdStart);
            mdEnd = XmlUtil.update(element, "endMd", mdEnd);

            XElement commonDataElement = element.Element(element.Name.Namespace+"commonData");//, element.getNamespace());
            if (commonDataElement != null)
                commonData = new WitsmlCommonData(commonDataElement);
        }
    }
}