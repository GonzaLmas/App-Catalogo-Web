
function cargarImagen(event) {
    var imagePreview = document.getElementById("imagePreview");
    var fileInput = document.getElementById("fileInput");

    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imagePreview.src = e.target.result;
            imagePreview.style.display = "block";
        };

        reader.readAsDataURL(fileInput.files[0]);
    }
}





