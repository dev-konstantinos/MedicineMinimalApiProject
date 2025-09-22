using MinimalApiProject.Models;

namespace MinimalApiProject.Data
{
    public static class MedicineStorage
    {
        public static List<MedicineModel> medicineList = new List<MedicineModel>
        {
            new MedicineModel{Id = 1, Name="Aspirin", Dosage="500 mg", Description="Pain relief", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(12), Quantity=50},
            new MedicineModel{Id = 2, Name="Paracetamol", Dosage="500 mg", Description="Fever reducer", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=100},
            new MedicineModel{Id = 3, Name="Ibuprofen", Dosage="200 mg", Description="Anti-inflammatory", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(18), Quantity=75},
            new MedicineModel{Id = 4, Name="Amoxicillin", Dosage="250 mg", Description="Antibiotic", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(12), Quantity=40},
            new MedicineModel{Id = 5, Name="Metformin", Dosage="500 mg", Description="Blood sugar control", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=60},
            new MedicineModel{Id = 6, Name="Lisinopril", Dosage="10 mg", Description="Blood pressure control", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=30},
            new MedicineModel{Id = 7, Name="Omeprazole", Dosage="20 mg", Description="Acid reducer", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=50},
            new MedicineModel{Id = 8, Name="Simvastatin", Dosage="20 mg", Description="Cholesterol control", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=45},
            new MedicineModel{Id = 9, Name="Albuterol", Dosage="2 mg", Description="Bronchodilator", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=25},
            new MedicineModel{Id = 10, Name="Hydrochlorothiazide", Dosage="25 mg", Description="Diuretic", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=40},
            new MedicineModel{Id = 11, Name="Prednisone", Dosage="10 mg", Description="Steroid anti-inflammatory", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(18), Quantity=30},
            new MedicineModel{Id = 12, Name="Cetirizine", Dosage="10 mg", Description="Allergy relief", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=60},
            new MedicineModel{Id = 13, Name="Warfarin", Dosage="5 mg", Description="Blood thinner", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(12), Quantity=20},
            new MedicineModel{Id = 14, Name="Furosemide", Dosage="40 mg", Description="Diuretic", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=35},
            new MedicineModel{Id = 15, Name="Citalopram", Dosage="20 mg", Description="Antidepressant", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=50},
            new MedicineModel{Id = 16, Name="Azithromycin", Dosage="500 mg", Description="Antibiotic", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(12), Quantity=30},
            new MedicineModel{Id = 17, Name="Gabapentin", Dosage="300 mg", Description="Neuropathic pain", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=40},
            new MedicineModel{Id = 18, Name="Levothyroxine", Dosage="50 mcg", Description="Thyroid hormone", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(36), Quantity=60},
            new MedicineModel{Id = 19, Name="Clopidogrel", Dosage="75 mg", Description="Blood thinner", IsImportant=true, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(24), Quantity=25},
            new MedicineModel{Id = 20, Name="Lorazepam", Dosage="1 mg", Description="Anxiety relief", IsImportant=false, ExpDate=DateOnly.FromDateTime(DateTime.Now).AddMonths(18), Quantity=20}
        };
    }
}
