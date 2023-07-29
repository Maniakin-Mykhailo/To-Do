function toggleComplete(checkbox) {
    // Toggle text crosshatching when checkbox state changes
    var taskTitle = checkbox.parentNode;
    if (checkbox.checked) {
        taskTitle.classList.add("completed");
    } else {
        taskTitle.classList.remove("completed");
    }
}