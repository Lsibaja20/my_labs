
let elements = document.getElementById('lista');

function agregar() {
    let input = elements.children.length;
    input = input + 1;
    let newInput = document.createElement("li");
    newInput.textContent = 'Elements ' + input;
    elements.appendChild(newInput);
}

function borrar() {
    if (elements.children.length > 0) {
        elements.children[elements.children.length - 1].remove();

    }
}
let colorConfirmacion = false;
function cambiarFondo() {
    if (colorConfirmacion == false) {
        document.body.style.backgroundColor = 'yellow';
        colorConfirmacion = true;
    }
    else {
        document.body.style.backgroundColor = 'white';
        colorConfirmacion = false;
    }
}