const apiUrl = "https://localhost:7041/api/Notlar";
let notlar = [];
const divNotlar = document.getElementById("notlar");
const txtBaslik = document.getElementById("baslik");
const txtIcerik = document.getElementById("icerik");
const frmNot = document.getElementById("frmNot");
const btnSil = document.getElementById("sil");
const btnYeni = document.getElementById("yeni");
let seciliNot = null;

function notlariGetir(){   
    axios.get(apiUrl).then(res => {
        notlar = res.data;
        notlariListele();
    })
}

function notlariListele() {
    divNotlar.innerHTML = "";

    for(const not of notlar){
        const a = document.createElement("a");  
        a.not = not;          
        a.href = "#";
        a.className = "list-group-item list-group-item-action";            
        a.textContent = not.baslik;            
        a.onclick = (e) => notuGoster(not);        
        divNotlar.append(a);
    }
}

function notuGoster(not){
    seciliNot = not;
    frmNot.style.display = "block"
    txtBaslik.value = not.baslik;
    txtIcerik.value = not.icerik;
    secimiGuncelle();
}

function secimiGuncelle(){
    divNotlar.childNodes.forEach(el => {
        if(el.not.id == seciliNot?.id ){
            el.classList.add("active");
        }
        else{
            el.classList.remove("active");
        }
    })
}

btnYeni.onclick = (e) => {
    axios.post(apiUrl, { baslik:"Yeni Not", icerik: ""}).then(res => {
        notlar.push(res.data);
        seciliNot = res.data;
        notlariListele();
        secimiGuncelle();
        notuGoster(res.data);
    });
}

btnSil.onclick = (e) => {
    axios.delete(apiUrl + "/" + seciliNot.id).then(res => {
        let sid = notlar.indexOf(seciliNot);
        notlar.splice(sid,1);
        notlariListele();
        frmNot.style.display = "none";
        if(notlar.length)
            notuGoster(notlar[Math.min(sid, notlar.length - 1)]);
    });
}

frmNot.onsubmit = (e) => {
    e.preventDefault();
    let not = {
        id:seciliNot.id,
        baslik: txtBaslik.value,
        icerik: txtIcerik.value
    };

    axios.put(apiUrl + "/" + not.id, not).then(res => {
        seciliNot.baslik = not.baslik;
        seciliNot.icerik = not.icerik;
        notlariListele();
        notuGoster(not);
    }).catch(error => console.log(error));
}

notlariGetir();
