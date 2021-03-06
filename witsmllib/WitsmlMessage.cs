/*
nwitsml Copyright 2010 Setiri LLC
Derived from the jwitsml project, Copyright 2010 Statoil ASA
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
namespace witsmllib
{

    //import java.util.Date;

    /**
     * Java representation of a WITSML "message".
     *
     * @author <a href="mailto:info@nwitsml.org">NWitsml</a>
     */
    public abstract class WitsmlMessage : WitsmlObject
    {

        /** The WITSML type name */
        private  static String WITSML_TYPE = "message";

        protected DateTime? time; // dTim
        protected String activityCode; // activityCode

        /**
         * Create a well object with specified ID.
         *
         * @param id  ID of this well.
         */
        protected WitsmlMessage(WitsmlServer server, String id, String name,
                                WitsmlObject parent, String parentId)
        
            :base(server, WITSML_TYPE, id, name, parent, parentId)
        {}

        public DateTime? getTime()
        {
            return time;
        }

        public String getActivityCode()
        {
            return activityCode;
        }
    }
}