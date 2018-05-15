using feesandFacilities.data_classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feesandFacilities
{
    class Program
    {
        private static dormitories_table dormitory;

        static void Main(string[] args)
        {
            Console.WriteLine("Testing to see if there are any errors");


            ArrayList facilityList = new ArrayList();
            ArrayList option_list_en, option_list_tr;


            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();
            option_list_en.Add("Heating");
            option_list_en.Add("Cooling");
            option_list_tr.Add("Isıtma");
            option_list_tr.Add("Soğutma");

            facilityList.Add(new facility_data(
                                "",
                                "Central conditioning system",
                                "Merkezi Isıtma",
                               option_list_en,
                                option_list_tr));


            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Refrigerator",
                                "Buzdolabı",
                               option_list_en,
                                option_list_tr));

            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Air-condition",
                                "Klima",
                               option_list_en,
                                option_list_tr));

            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Room tel.",
                                "Oda Telefonmu",
                               option_list_en,
                                option_list_tr));

            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Generator",
                                "Jeneratör",
                               option_list_en,
                                option_list_tr));

            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Cafeteria",
                                "Kafeterya",
                               option_list_en,
                                option_list_tr));


            option_list_en = new ArrayList();
            option_list_tr = new ArrayList();


            facilityList.Add(new facility_data(
                                "",
                                "Laundry",
                                "Çamaşırhane",
                               option_list_en,
                                option_list_tr));






            using (fees_facilities_Entities context = new fees_facilities_Entities())
            {
                foreach (facility_data data in facilityList)
                {
                    facility_table facility = new facility_table { facility_icon_url = data.facility_icon_url };
                    context.facility_table.Add(facility);
                    context.SaveChanges();
                    facility_option facility_Option = new facility_option { facility_id = facility.id };

                    if (data.facility_options_list_en.Count > 0) { 
                    context.facility_option.Add(facility_Option);
                        context.SaveChanges();
                    }


                    //English

                    language_table language_Table_EN = context.language_table.FirstOrDefault(l => l.language_code == "EN");
                    context.facility_table_translation.Add(new facility_table_translation
                    {
                        facility_table_non_trans_id = facility.id,
                        facility_title = data.facility_title_en,
                        language_id = language_Table_EN.id,
                        facility_description = ""
                    });
                    context.SaveChanges();

                    foreach (String data_option in data.facility_options_list_en) {
                        //Facility options english
                                context.facility_option_translation.Add(new facility_option_translation
                            {
                                facility_option_non_trans_id = facility_Option.id,
                                language_id = language_Table_EN.id,
                                facility_option = data_option,
                                facility_option_description = ""

                            });
                        context.SaveChanges();
                    }

                    language_table language_Table_TR = context.language_table.FirstOrDefault(l => l.language_code == "TR");
                    foreach (String data_option in data.facility_options_list_tr)
                    {
                        //Facility options Turkish
                        context.facility_option_translation.Add(new facility_option_translation
                        {
                            facility_option_non_trans_id = facility_Option.id,
                            language_id = language_Table_TR.id,
                            facility_option = data_option,
                            facility_option_description = ""

                        });
                        context.SaveChanges();
                    }


                    //Turkish
                    
                    context.facility_table_translation.Add(new facility_table_translation
                    {
                        facility_table_non_trans_id = facility.id,
                        facility_title = data.facility_title_tr,
                        language_id = language_Table_TR.id,
                        facility_description = ""
                    });
                    context.SaveChanges();


                   

                }



            }

            Console.WriteLine("Done processing, Adding changes");
                Console.Read();
        }
    }
}










// Adding the two languages
//context.language_table.Add(new language_table { name = "English Language", language_code = "EN" });
//  context.language_table.Add(new language_table { name = "Turkish Language", language_code = "TR" });

//context.dormitory_type.Add(new dormitory_type { });
//context.SaveChanges();
/* dormitory_type dormitory_Type = context.dormitory_type.FirstOrDefault(l => l.id >0);

 context.dormitory_type_translation.Add( new dormitory_type_translation
 { language_id = language_Table_EN.id, dormitory_type_non_trans_id=dormitory_Type.id, type_name= "Eastern Mediterranean University Dormitories on Campus Residence" });

 context.dormitory_type_translation.Add(new dormitory_type_translation
 { language_id = language_Table_TR.id, dormitory_type_non_trans_id = dormitory_Type.id, type_name = "DAÜ Yurtları (DAÜ Yutlarında Kayıtlar Dönemlik Yapılmaktadır)" });
 context.SaveChanges();*/


// context.dormitory_type.Add(new dormitory_type { });
//context.SaveChanges();
/* dormitory_type dormitory_Type1 = context.dormitory_type.FirstOrDefault(l => l.id > 1);


 context.dormitory_type_translation.Add(new dormitory_type_translation
 { language_id = language_Table_EN.id, dormitory_type_non_trans_id = dormitory_Type1.id, type_name = "EMU BOT (build-operate-transfer) Dormitories on Campus Residence" });

 context.dormitory_type_translation.Add(new dormitory_type_translation
 { language_id = language_Table_TR.id, dormitory_type_non_trans_id = dormitory_Type1.id, type_name = "DAÜ Yap - İşlet - Devret Yurtları (YİD Yurtlarına Kayıtlar Yıllık" });
 context.SaveChanges();*/


/* Add data for dormitories
 * 
 * 
 *  
                foreach(dormitory_data data in dormitoriesList) { 

                
                dormitory_type dormitory_Type = context.dormitory_type
                    .FirstOrDefault(l => l.id == l.dormitory_type_translation
                    .FirstOrDefault(x => x.type_name == data.dormitory_type)
                    .dormitory_type_non_trans_id);
               
              dormitory = new dormitories_table {
                   dormitory_type_id = dormitory_Type.id,
                   room_price_currency = data.room_price_currency,
                   room_price_currency_symbol = data.room_price_currency_symbol
              };

                context.dormitories_table.Add(dormitory);
                context.SaveChanges();

                    //English

                    language_table language_Table_EN = context.language_table.FirstOrDefault(l => l.language_code == "EN");
                    context.dormitories_table_translation.Add(new dormitories_table_translation {
                    language_id = language_Table_EN.id,
                    dormitories_table_non_trans_id = dormitory.id,
                    dormitory_address =data.dormitory_address,
                    gender_allocation = data.gender_allocation_EN,
                    rooms_payment_period = data.rooms_payment_period_EN,
                    dormitory_name = data.dormitory_name_EN
                });
                    //Turkish
                    language_table language_Table_TR = context.language_table.FirstOrDefault(l => l.language_code == "TR");
                    context.dormitories_table_translation.Add(new dormitories_table_translation
                    {
                        language_id = language_Table_TR.id,
                        dormitories_table_non_trans_id = dormitory.id,
                        dormitory_address = data.dormitory_address,
                        gender_allocation = data.gender_allocation_TR,
                        rooms_payment_period = data.rooms_payment_period_TR,
                        dormitory_name = data.dormitory_name_TR
                    });


                    context.SaveChanges();

                }
 * 
 *  ArrayList dormitoriesList = new ArrayList();
             dormitoriesList.Add(new dormitory_data(
                 "Eastern Mediterranean University Dormitories on Campus Residence",

                 "TL",
                 "TL_SYMBOL",
                 "",
                 "for male Students",
                 "Per semester",
                 "EMU 1",

                 "Erkek Yurdu",
                 "Dönemlik",
                 "DAÜ 1"));

            dormitoriesList.Add(new dormitory_data(
                     "Eastern Mediterranean University Dormitories on Campus Residence",

                     "TL",
                     "TL_SYMBOL",
                     "",
                     "For female",
                     "Per semester",
                     "EMU Sabanci",
                      "Kız Yurdu",
                     "Dönemlik",
                     "DAÜ Sabancı Yurdu"
                     ));

            dormitoriesList.Add(new dormitory_data(
               "Eastern Mediterranean University Dormitories on Campus Residence",

               "TL",
               "TL_SYMBOL",
               "",
               "for male students",
               "Per semester",
               "EMU 2",
               "Erkek Yurdu",
               "Dönemlik",
               "DAÜ 2"));


            dormitoriesList.Add(new dormitory_data(
               "Eastern Mediterranean University Dormitories on Campus Residence",

               "TL",
               "TL_SYMBOL",
               "",
               "separate blocks for female and male students",
               "Per semester",
               "EMU 3",
                "Kız/Erkek Bloklan",
               "Dönemlik",
               "DAÜ 3"));

            dormitoriesList.Add(new dormitory_data(
               "Eastern Mediterranean University Dormitories on Campus Residence",

               "TL",
               "TL_SYMBOL",
               "",
               "for female students",
               "Per semester",
               "EMU 4",
               "Kız Yurdu",
               "Dönemlik",
               "DAÜ 4 Yurdu"));

            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate floors",
               "Academic Year",
               "Alfam",
               "Kız/Erkek Katları",
               "Akademik Yıl",
               "Alfam Öğrenci Yurdu"));


            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate floors",
               "Academic Year",
               "Uğursal",
               "Kız/Erkek Katları",
               "Akademik Yıl",
               "Uğursal  Öğrenci Yurdu"));


            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate floors",
               "Academic Year",
               "Marmara",
               "Kız/Erkek Katları",
               "Akademik Yıl",
               "Marmara  Öğrenci Yurdu"));


            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students in separate blocks",
               "Academic Year",
               "Akdeniz",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Akdeniz  Öğrenci Yurdu"));

            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate blocks",
               "Academic Year",
               "Longson",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Longson  Öğrenci Yurdu"));


            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students in separate blocks",
               "Academic Year",
               "Homedorm",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Homedorm  Öğrenci Yurdu"));


            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students",
               "Academic Year",
               "Ramen",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Ramen  Öğrenci Yurdu"));

            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate blocks",
               "Academic Year",
               "Prime Living",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Prime Living  Öğrenci Yurdu"));

            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate blocks",
               "Academic Year",
               "Golden Plus",
               "Kız/Erkek Blokları",
               "Akademik Yıl",
               "Golden Plus  Öğrenci Yurdu"));

            dormitoriesList.Add(new dormitory_data(
               "EMU BOT (build-operate-transfer) Dormitories on Campus Residence",

               "USD",
               "USDSYMBOL",
               "",
               "For female and male students on separate blocks",
               "Academic Year",
               "Kamacıoğlu",
               "Kız/Erkek Katları",
               "Akademik Yıl",
               "Kamacıoğlu Öğrenci Yurdu"));


        
 */
