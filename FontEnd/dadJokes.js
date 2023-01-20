const api_url = "https://localhost:7134/api/Jokes"

async function loadData(url){

    
    const tablebody = document.querySelector('#tbody');
    
    const response = await fetch(url);
    const data = await response.json();
    

    data.forEach(jokeObj => {
        let{id,category,setup,punch} = jokeObj;
        tablebody.innerHTML += `<tr>
        <td>${id}</td>
        <td>${category}</td>
        <td>${setup}</td>
        <td>${punch}</td>
        </tr>`
    });
    
}

loadData(api_url, document.querySelector("table"));
const api_url = "https://localhost:7134/api/Jokes"
const random_URL ="https://localhost:7134/api/Jokes/random"

async function loadData(url){

    
    const tablebody = document.querySelector('#tbody');
    
    const response = await fetch(url);
    const data = await response.json();
    

    data.forEach(jokeObj => {
        let{id,category,setup,punch} = jokeObj;
        tablebody.innerHTML += `<tr>
        <td>${id}</td>
        <td>${category}</td>
        <td>${setup}</td>
        <td>${punch}</td>
        </tr>`
    });
    
}

loadData(api_url, document.querySelector("table"));

async function loadRandom(url){
    
    const response = await fetch(url);
    const data = await response.json();
    
    
    document.getElementById("randomJoke").innerHTML= `${data.setup} <div></div> ${data.punch}`    
}

loadRandom(random_URL);
