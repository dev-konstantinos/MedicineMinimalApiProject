using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalApiProject.Data;
using MinimalApiProject.DTOs;
using MinimalApiProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET: getting the list of all medicines
app.MapGet("/api/medicine", (ILogger<Program> logger) =>
{
    logger.LogInformation("Getting all medicines: {Count} units", MedicineStorage.medicineList.Count);
    return Results.Ok(MedicineStorage.medicineList);
}).WithName("GetMedicines")
.Produces<IEnumerable<MedicineModel>>(200);

// GET: getting a medicine by id
app.MapGet("/api/medicine/{id:int}", (int id, ILogger<Program> logger) =>
{
    var med = MedicineStorage.medicineList.FirstOrDefault(x => x.Id == id);
    if (med is null)
    {
        logger.LogWarning("Medicine with Id {Id} not found", id);
        return Results.NotFound();
    }
    logger.LogInformation("Fetched medicine with Id {Id}", id);
    return Results.Ok(med);
}).WithName("GetMedicine")
.Produces<MedicineModel>(200)
.Produces(404);

// POST: adding a new medicine
app.MapPost("/api/medicine", (IValidator<MedicineDTO> validator, [FromBody] MedicineDTO medicineDTO, ILogger<Program> logger) =>
{
    var validationResult = validator.ValidateAsync(medicineDTO).GetAwaiter().GetResult();
    if (!validationResult.IsValid)
    {
        logger.LogWarning("Invalid data received for create");
        return Results.BadRequest(validationResult.Errors.FirstOrDefault()?.ToString());
    }
    // Checking if Name + Dosage + ExpDate combination is unique
    if (MedicineStorage.medicineList.Any(x =>
        x.Name.Equals(medicineDTO.Name, StringComparison.OrdinalIgnoreCase) &&
        x.Dosage.Equals(medicineDTO.Dosage, StringComparison.OrdinalIgnoreCase) &&
        x.ExpDate == medicineDTO.ExpDate))
    {
        logger.LogWarning("Medicine with same Name, Dosage and ExpDate already exists");
        return Results.BadRequest("Medicine with this data already exists!");
    }
    MedicineModel medicine = new()
    {
        Id = MedicineStorage.medicineList.Any() ? MedicineStorage.medicineList.Max(x => x.Id) + 1 : 1,
        Name = medicineDTO.Name,
        Dosage = medicineDTO.Dosage,
        Description = medicineDTO.Description,
        IsImportant = medicineDTO.IsImportant,
        ExpDate = medicineDTO.ExpDate,
        Quantity = medicineDTO.Quantity
    };
    MedicineStorage.medicineList.Add(medicine);
    logger.LogInformation("Medicine with Id {Id}, Name {Name} created successfully", medicine.Id, medicine.Name);
    return Results.CreatedAtRoute("GetMedicine", new { id = medicine.Id }, medicine);
})
.WithName("CreateMedicine")
.Accepts<MedicineDTO>("application/json")
.Produces<MedicineModel>(201)
.Produces(400);

// PUT: updating an existing medicine
app.MapPut("/api/medicine/{id:int}", (int id, IValidator<MedicineDTO> validator, [FromBody] MedicineDTO medicineDTO, ILogger<Program> logger) =>
{
    var validationResult = validator.ValidateAsync(medicineDTO).GetAwaiter().GetResult();
    if (!validationResult.IsValid)
    {
        logger.LogWarning("Invalid data received for update");
        return Results.BadRequest(validationResult.Errors.FirstOrDefault()?.ToString());
    }
    var med = MedicineStorage.medicineList.FirstOrDefault(x => x.Id == id);
    if (med is null)
    {
        logger.LogWarning("Update failed: medicine with Id {Id} not found", id);
        return Results.NotFound();
    }
    // Checking if Name + Dosage + ExpDate combination is unique
    if (MedicineStorage.medicineList.Any(x =>
        x.Id != id &&
        x.Name.Equals(medicineDTO.Name, StringComparison.OrdinalIgnoreCase) &&
        x.Dosage.Equals(medicineDTO.Dosage, StringComparison.OrdinalIgnoreCase) &&
        x.ExpDate == medicineDTO.ExpDate))
    {
        logger.LogWarning("Medicine with same Name, Dosage and ExpDate already exists");
        return Results.BadRequest("Medicine with this data already exists!");
    }
    med.Name = medicineDTO.Name;
    med.Dosage = medicineDTO.Dosage;
    med.Description = medicineDTO.Description;
    med.IsImportant = medicineDTO.IsImportant;
    med.ExpDate = medicineDTO.ExpDate;
    med.Quantity = medicineDTO.Quantity;
    logger.LogInformation("Medicine with Id {Id} updated successfully", id);
    return Results.Ok(med);
})
.WithName("EditMedicine")
.Accepts<MedicineDTO>("application/json")
.Produces<MedicineModel>(200)
.Produces(400)
.Produces(404);

// DELETE: deleting a medicine by id
app.MapDelete("/api/medicine/{id:int}", (int id, ILogger<Program> logger) =>
{
    var med = MedicineStorage.medicineList.FirstOrDefault(x => x.Id == id);
    if (med is null)
    {
        logger.LogWarning("Delete failed: medicine with Id {Id} not found", id);
        return Results.NotFound();
    }
    MedicineStorage.medicineList.Remove(med);
    logger.LogInformation("Medicine with Id {Id} deleted", id);
    return Results.NoContent();
}).WithName("DeleteMedicine")
.Produces(204)
.Produces(404);

app.UseHttpsRedirection();
app.Run();
