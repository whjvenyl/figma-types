package io.quicktype;

import java.util.Map;
import com.fasterxml.jackson.annotation.*;

/**
 * The user who left the comment
 *
 * A description of a user
 */
public class User {
    private String handle;
    private String imgURL;

    @JsonProperty("handle")
    public String getHandle() { return handle; }
    @JsonProperty("handle")
    public void setHandle(String value) { this.handle = value; }

    @JsonProperty("img_url")
    public String getImgURL() { return imgURL; }
    @JsonProperty("img_url")
    public void setImgURL(String value) { this.imgURL = value; }
}
