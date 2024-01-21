function createBestSellers(product) {
    return `
        <div class="col-md-3 card-style">
            <div class="card cursor-pointer shadow-hover">
                <div class="card-img-top card-img-style mx-auto ">
                    <img src="${product.imgSrc}" class="img-fluid">
                </div>
                <div class="card-body text-start">
                    <h5>${product.title}</h5>
                    <p class="mb-0">${product.price}</p>
                    <div class="row mt-0">
                        ${product.categories.map(category => `
                            <div class="col-4 bg-light m-2">
                                ${category}
                            </div>
                        `).join('')}
                    </div>
                    <button class="btn btn-danger w-100 mt-2">
                        Add To Cart
                    </button>
                </div>
            </div>
        </div>
    `;
}

$(document).ready(function () {
    // Assume you have a container div with the id "bestSellersContainer" in your HTML
    var container = $('#bestSellersContainer');

    // Make an AJAX request to load the JSON data
    $.getJSON('scripts/data-storage.json', function (data) {
        // Get the first 7 items from the data
        var firstSevenProducts = data.slice(0, 7);

        // Iterate through the first 7 items and append the HTML structure
        $.each(firstSevenProducts, function (index, product) {
            container.append(createBestSellers(product));
        });
    });
});
