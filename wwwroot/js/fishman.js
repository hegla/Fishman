const uri = 'api/Countries';
let countries = [];

function getCountries() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCountries(data))
        .catch(error => console.error('Unable to get countries.', error));
}

function addCountry() {
    const addNameTextbox = document.getElementById('add-name');
    const addPopTextbox = document.getElementById('add-pop');

    console.log(addNameTextbox.value.trim());

    const country = {
        name: addNameTextbox.value.trim(),
        population: parseInt(addPopTextbox.value)
    };

    console.log(uri);

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(country)
    })
        .then(response => response.json())
        .then(() => {
            getCountries();
            addNameTextbox.value = '';
            addPopTextbox.value = '';
        })
        .catch(error => console.error('Unable to add country.', error));
    console.log('success');
}

function deleteCountry(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCountries())
        .catch(error => console.error('Unable to delete country.', error));
}

function displayEditForm(id) {
    console.log('id in display edit', id);
    const country = countries.find(country => country.countryId === id);

    document.getElementById('edit-id').value = country.countryId;
    console.log(country.id);
    document.getElementById('edit-name').value = country.name;
    document.getElementById('edit-pop').value = country.population;
}


function updateCountry() {
    const id = document.getElementById('edit-id').value;
    console.log('id in update ', id);
    const country = {
        countryId: parseInt(id, 10),
        name: document.getElementById('edit-name').value.trim(),
        population: parseInt(document.getElementById('edit-pop').value)
    };

    fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(country)
    })
        .then(() => getCountries())
        .catch(error => console.error('Unable to update country.', error));

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCountries(data) {
    const tBody = document.getElementById('countries');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(country => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${country.countryId})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCountry(${country.countryId})`);
        console.log(country.id);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(country.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(country.population);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    countries = data;
}





