
// Fetch data from API endpoint
    async function fetchData() {
        const response = await fetch('https://localhost:44391/cars'); 
    const data = await response.json();
    return data;
    }

    // Update table body with fetched data
    async function updateTable() {
        const cars = await fetchData();
    const tbody = document.getElementById('carTableBody');

    // Clear existing table rows
    tbody.innerHTML = '';

        // Populate table with fetched data
        cars.forEach(car => {
            const row = document.createElement('tr');
    row.innerHTML = `
    <td>${car.shortName}</td>
    <td>${car.purpose}</td>
    <td>${car.vehicleMake}</td>
    <td>${car.license}</td>
    <td>${car.trackerDeviceId}</td>
    <td>${car.description}</td>
    <td><a href="/Cars/Edit/${car.id}">Edit</a> | <a href="/Cars/Delete/${car.id}">Delete</a></td>
    `;
    tbody.appendChild(row);
        });
    }