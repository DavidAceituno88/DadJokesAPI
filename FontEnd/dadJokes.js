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
    });const api_url = "https://localhost:7134/api/Jokes"const api_url = "https://localhost:7134/api/Jokes"
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

async function type(url){
    
    const responseType = await fetch(url);
    const types = await responseType.json();

    const selectBox = document.querySelector('#select_type')
    types.forEach(t =>
        {
            var opt =document.createElement('option');
            opt.value=t;
            opt.innerHTML=t;
            selectBox.appendChild(opt); 
        });   
        
}

type("https://localhost:7134/api/Jokes/types");


async function jokeByType (){
const jokeurl = document.getElementById("joke-content");
//This block displays a random "general" joke when the type.html is loaded.
if(jokeurl.innerHTML=" "){
    const holderResponse = await fetch('https://localhost:7134/api/Jokes/bytype?type=general');
    const placeHolder = await holderResponse.json();
    jokeurl.innerHTML = `${placeHolder.setup} <div></div> ${placeHolder.punch}`;
}

//Once they select a type from the select-box and click the button search this block runs.
    document.getElementById("search_type").onclick = async () =>{
        let x = document.getElementById("select_type");
        let type = x.value;  
        
        const response = await fetch(`https://localhost:7134/api/Jokes/bytype?type=${type}`);
        const joke = await response.json();

        jokeurl.innerHTML= `${joke.setup} <div></div> ${joke.punch}`;        
    }

    
}
jokeByType();
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

async function type(url){
    
    const responseType = await fetch(url);
    const types = await responseType.json();

    const selectBox = document.querySelector('#select_type')
    types.forEach(t =>
        {
            var opt =document.createElement('option');
            opt.value=t;
            opt.innerHTML=t;
            selectBox.appendChild(opt); 
        });   
        
}

type("https://localhost:7134/api/Jokes/types");


async function jokeByType (){

    
    document.getElementById("search_type").onclick = async () =>{
        let x = document.getElementById("select_type");
        let type = x.value;  
        
        const response = await fetch(`https://localhost:7134/api/Jokes/bytype?type=${type}`);
        const joke = await response.json();

        document.getElementById("joke-content").innerHTML= `${joke.setup} <div></div> ${joke.punch}`;        
    }

    
}
jokeByType();
    
}

loadData(api_url, document.querySelector("table"));

async function loadRandom(url){
    
    const response = await fetch(url);
    const data = await response.json();
    
    
    document.getElementById("randomJoke").innerHTML= `${data.setup} <div></div> ${data.punch}`    
}

loadRandom(random_URL);
