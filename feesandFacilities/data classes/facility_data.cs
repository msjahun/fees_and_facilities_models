using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feesandFacilities.data_classes
{
   public class facility_data
    {
        public facility_data(
        String facility_icon_url,
        String facility_title_en,
        String facility_title_tr,
        ArrayList facility_options_list_en,
        ArrayList facility_options_list_tr )
        {
            this.facility_icon_url = facility_icon_url;
            this.facility_title_en = facility_title_en;
            this.facility_title_tr = facility_title_tr;
            this.facility_options_list_en = facility_options_list_en;
            this.facility_options_list_tr = facility_options_list_tr;

        }

        public String facility_icon_url;
        public String facility_title_en;
        public String facility_title_tr;
        public ArrayList facility_options_list_en;
        public ArrayList facility_options_list_tr;


    }
}
