var booleano = false;

function topFunction() {
	var info = document.getElementById('informacion');
	booleano = !booleano;

	if (booleano) {
		info.style.visibility = "visible";
	} else {
		info.style.visibility = "hidden";
	}
}