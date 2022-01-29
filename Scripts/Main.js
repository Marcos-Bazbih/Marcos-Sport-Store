const heartIcons = document.getElementsByClassName("heart-icon");

for (let heart of heartIcons) {
    let isClicked = false;
    heart.onclick = () => {
        if (isClicked === false) {
            isClicked = true;
            heart.classList.add("item-liked");
        }
        else {
            isClicked = false;
            heart.classList.remove("item-liked");
        }
    }
}










const menu = document.getElementById("menu");
const menuItem = document.getElementsByClassName("menuItem");
const hamburger = document.getElementById("hamburger");

const topLine = document.getElementById("topLine");
const centerLine = document.getElementById("centerLine");
const bottomLine = document.getElementById("bottomLine");

let menuParam = false;

function toggleMenu() {
    if (menuParam == false) {
        topLine.style.transform = "rotate(45deg)";
        bottomLine.style.transform = "rotate(-45deg)";
        centerLine.style.transform = "translateX(-150%)";

        hamburger.style.borderColor = "white";
        hamburger.style.background = "black";
        topLine.style.background = "white";
        bottomLine.style.background = "white";
        centerLine.style.background = "white";

        menuBox.style.transform = "translateX(0%)";

        menuParam = true;
    }
    else {
        topLine.style.transform = "rotate(0deg) translateY(-200%)";
        bottomLine.style.transform = "rotate(0deg) translateY(200%)";
        centerLine.style.transform = "translateX(0%)";

        hamburger.style.borderColor = "black";
        hamburger.style.background = "white";
        topLine.style.background = "black";
        bottomLine.style.background = "black";
        centerLine.style.background = "black";

        menuBox.style.transform = "translateX(-100%)";

        menuParam = false;
    }
}

hamburger.onclick = () => toggleMenu();

for (const iterator of menuItem) {
    iterator.onclick = () => toggleMenu();
}