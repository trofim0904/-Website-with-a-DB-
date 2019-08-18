



       



menu.onclick=function myFunction(){
    var x=document.getElementById('myTopnav');

    if (x.className === "topnav"){
        x.className += " responsive";
    } else{
        x.className="topnav";
    }
}


var images = ['volkswagen_picture_for_main.PNG','picture_for_main.png'];
        
var slider = document.querySelector('#slider');
var img = slider.querySelector('img');

var i=0;
window.setInterval(function(){
    if (i==2) i=0;
    img.src = 'assets/img/' + images[i];
    i++;
    
},5000);

